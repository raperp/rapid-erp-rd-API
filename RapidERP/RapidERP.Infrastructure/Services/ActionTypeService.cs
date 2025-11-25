using Microsoft.EntityFrameworkCore;
using RapidERP.Application.DTOs.ActionTypeDTOs;
using RapidERP.Application.DTOs.Shared;
using RapidERP.Application.Interfaces;
using RapidERP.Domain.Entities.ActionTypeModels;
using RapidERP.Domain.Utilities;
using RapidERP.Infrastructure.Data;

namespace RapidERP.Infrastructure.Services;

public class ActionTypeService(RapidERPDbContext context, IShared shared) : IActionType
{
    RequestResponse requestResponse { get; set; }

    public async Task<RequestResponse> CreateBulk(List<ActionTypePOST> masterPOSTs)
    {
        try
        {
            requestResponse = new();

            foreach (var masterPOST in masterPOSTs)
            {
                var task = CreateSingle(masterPOST);
                var result = await Task.WhenAll(task);
                requestResponse.Message = result.FirstOrDefault().Message;
                requestResponse.IsSuccess = result.FirstOrDefault().IsSuccess;
                requestResponse.StatusCode = result.FirstOrDefault().StatusCode;
                requestResponse.Data = result.FirstOrDefault().Data;
            }

            //requestResponse = new()
            //{
            //    StatusCode = $"{HTTPStatusCode.Created} {HTTPStatusCode.StatusCode201}",
            //    IsSuccess = true,
            //    Message = ResponseMessage.CreateSuccess,
            //    Data = masterPOSTs
            //};

            return requestResponse;
        }

        catch
        {
            requestResponse = new()
            {
                StatusCode = $"{HTTPStatusCode.InternalServerError} {HTTPStatusCode.StatusCode500}",
                IsSuccess = false,
                Message = ResponseMessage.WrongDataInput
            };

            return requestResponse;
        }
    }

    public async Task<RequestResponse> CreateSingle(ActionTypePOST masterPOST)
    {
        try
        {
            await using var transaction = await context.Database.BeginTransactionAsync();
            var isExists = await context.ActionTypes.AsNoTracking().AnyAsync(x => x.Name == masterPOST.Name);

            if (isExists == false)
            {
                ActionType masterData = new();
                masterData.LanguageId = masterPOST.LanguageId;
                masterData.Name = masterPOST.Name;
                masterData.Description = masterPOST.Description;
                masterData.CreatedBy = (masterPOST.IsDraft == false) ? masterPOST.ActionBy : null;
                masterData.CreatedAt = (masterPOST.IsDraft == false) ? DateTime.Now : null;
                masterData.DraftedBy = (masterPOST.IsDraft == true) ? masterPOST.ActionBy : null;
                masterData.DraftedAt = (masterPOST.IsDraft == true) ? DateTime.Now : null;
                masterData.UpdatedBy = null;
                masterData.UpdatedAt = null;
                masterData.DeletedBy = null;
                masterData.DeletedAt = null;

                await context.ActionTypes.AddAsync(masterData);
                await context.SaveChangesAsync();

                ActionTypeAudit audit = new();
                audit.ActionTypeId = masterData.Id;
                audit.LanguageId = masterPOST.LanguageId;
                audit.ExportTypeId = masterPOST.ExportTypeId;
                audit.ExportTo = masterPOST.ExportTo;
                audit.SourceURL = masterPOST.SourceURL;
                audit.Name = masterPOST.Name;
                audit.Description = masterPOST.Description;
                audit.Browser = masterPOST.Browser;
                audit.Location = masterPOST.Location;
                audit.DeviceIP = masterPOST.DeviceIP;
                audit.LocationURL = masterPOST.LocationURL;
                audit.DeviceName = masterPOST.DeviceName;
                audit.Latitude = masterPOST.Latitude;
                audit.Longitude = masterPOST.Longitude;
                audit.ActionBy = masterPOST.ActionBy;
                audit.ActionAt = DateTime.Now;

                await context.ActionTypeAudits.AddAsync(audit);
                await context.SaveChangesAsync();
                await transaction.CommitAsync();

                requestResponse = new()
                {
                    StatusCode = $"{HTTPStatusCode.Created} {HTTPStatusCode.StatusCode201}",
                    IsSuccess = true,
                    Message = ResponseMessage.CreateSuccess,
                    Data = masterPOST
                };
            }

            else
            {
                requestResponse = new()
                {
                    StatusCode = $"{HTTPStatusCode.Conflict} {HTTPStatusCode.StatusCode409}",
                    IsSuccess = false,
                    Message = $"{ResponseMessage.RecordExists} {masterPOST.Name}"
                };
            }

            return requestResponse;
        }

        catch
        {
            requestResponse = new()
            {
                StatusCode = $"{HTTPStatusCode.BadRequest} {HTTPStatusCode.StatusCode400}",
                IsSuccess = false,
                Message = ResponseMessage.WrongDataInput
            };

            return requestResponse;
        }
    }

    public async Task<RequestResponse> Delete(int id)
    {
        try
        {
            await using var transaction = await context.Database.BeginTransactionAsync();
            var isAuditExists = await context.ActionTypeAudits.AsNoTracking().AnyAsync(x => x.ActionTypeId == id);

            if (isAuditExists == false)
            {
                requestResponse = new()
                {
                    StatusCode = $"{HTTPStatusCode.NotFound} {HTTPStatusCode.StatusCode404}",
                    IsSuccess = false,
                    Message = ResponseMessage.NoRecordFound
                };
            }

            else
            {
                await context.ActionTypeAudits.Where(x => x.ActionTypeId == id).ExecuteDeleteAsync();
            }

            var isExists = await context.ActionTypes.AsNoTracking().AnyAsync(x => x.Id == id);

            if (isExists == false)
            {
                requestResponse = new()
                {
                    StatusCode = $"{HTTPStatusCode.NotFound} {HTTPStatusCode.StatusCode404}",
                    IsSuccess = false,
                    Message = ResponseMessage.NoRecordFound
                };
            }

            else
            {
                await context.ActionTypes.Where(x => x.Id == id).ExecuteDeleteAsync();
                await transaction.CommitAsync();
            }

            requestResponse = new()
            {
                StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
                IsSuccess = true,
                Message = ResponseMessage.DeleteSuccess
            };

            return requestResponse;
        }

        catch (Exception ex)
        {
            requestResponse = new()
            {
                StatusCode = $"{HTTPStatusCode.InternalServerError} {HTTPStatusCode.StatusCode500}",
                IsSuccess = false,
                Message = ex.Message
            };

            return requestResponse;
        }
    }

    public async Task<RequestResponse> GetAll(int skip, int take)
    {
        try
        {
            var data = (from at in context.ActionTypes
                        join l in context.Languages on at.LanguageId equals l.Id
                        select new
                        {
                            at.Id,
                            Language = l.Name,
                            at.Name,
                            at.Description,
                            at.CreatedBy,
                            at.CreatedAt,
                            at.DraftedBy,
                            at.DraftedAt,
                            at.UpdatedBy,
                            at.UpdatedAt,
                            at.DeletedBy,
                            at.DeletedAt
                        }).AsNoTracking().AsQueryable();

            if (skip == 0 || take == 0)
            {
                var result = await data.ToListAsync();

                requestResponse = new()
                {
                    StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
                    IsSuccess = true,
                    Message = ResponseMessage.FetchSuccess,
                    Data = result
                };
            }

            else
            {
                var result = await data.Skip(skip).Take(take).ToListAsync();

                requestResponse = new()
                {
                    StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
                    IsSuccess = true,
                    Message = ResponseMessage.FetchSuccessWithPagination,
                    Data = result
                };
            }

            return requestResponse;
        }

        catch (Exception ex)
        {
            requestResponse = new()
            {
                StatusCode = $"{HTTPStatusCode.BadRequest} {HTTPStatusCode.StatusCode400}",
                IsSuccess = false,
                Message = ex.Message
            };

            return requestResponse;
        }
    }

    public async Task<RequestResponse> GetAllAudits(int skip, int take)
    {
        try
        {
            var data = (from ata in context.ActionTypeAudits
                        join at in context.ActionTypes on ata.ActionTypeId equals at.Id
                        join l in context.Languages on ata.LanguageId equals l.Id
                        join et in context.ExportTypes on ata.ExportTypeId equals et.Id
                        select new
                        {
                            ata.Id,
                            ActionType = at.Name,
                            Language = l.Name,
                            ExportType = et.Name,
                            ata.ExportTo,
                            ata.SourceURL,
                            ata.Name,
                            ata.Description,
                            ata.Browser,
                            ata.Location,
                            ata.DeviceIP,
                            ata.LocationURL,
                            ata.DeviceName,
                            ata.Latitude,
                            ata.Longitude,
                            ata.ActionBy,
                            ata.ActionAt
                        }).AsNoTracking().AsQueryable();

            if (skip == 0 || take == 0)
            {
                var result = await data.ToListAsync();

                requestResponse = new()
                {
                    StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
                    IsSuccess = true,
                    Message = ResponseMessage.FetchSuccess,
                    Data = result
                };
            }

            else
            {
                var result = await data.Skip(skip).Take(take).ToListAsync();

                requestResponse = new()
                {
                    StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
                    IsSuccess = true,
                    Message = ResponseMessage.FetchSuccessWithPagination,
                    Data = result
                };
            }

            return requestResponse;
        }

        catch (Exception ex)
        {
            requestResponse = new()
            {
                StatusCode = $"{HTTPStatusCode.InternalServerError} {HTTPStatusCode.StatusCode500}",
                IsSuccess = false,
                Message = ex.Message
            };

            return requestResponse;
        }
    }

    public async Task<dynamic> GetSingle(int id)
    {
        var result = await shared.GetSingle<ActionType>(id);
        return result;
    }

    public async Task<dynamic> SoftDelete(DeleteDTO softDelete)
    {
        var result = await shared.SoftDelete<ActionType>(softDelete);
        return result;
    }

    public async Task<RequestResponse> Update(ActionTypePUT masterPUT)
    {
        try
        {
            await using var transaction = await context.Database.BeginTransactionAsync();
            var isExists = await context.ActionTypes.AsNoTracking().AnyAsync(x => x.Name == masterPUT.Name && x.Id != masterPUT.Id);

            if (isExists == false)
            {
                ActionDTO actionDTO = new();
                actionDTO.UpdatedBy = (masterPUT.IsDraft == false) ? masterPUT.ActionBy : null;
                actionDTO.UpdatedAt = (masterPUT.IsDraft == false) ? DateTime.Now : null;
                actionDTO.DraftedBy = (masterPUT.IsDraft == true) ? masterPUT.ActionBy : null;
                actionDTO.DraftedAt = (masterPUT.IsDraft == true) ? DateTime.Now : null;

                await context.ActionTypes.Where(x => x.Id == masterPUT.Id).ExecuteUpdateAsync(x => x
                .SetProperty(x => x.LanguageId, masterPUT.LanguageId)
                .SetProperty(x => x.Name, masterPUT.Name)
                .SetProperty(x => x.Description, masterPUT.Description)
                .SetProperty(x => x.UpdatedBy, actionDTO.UpdatedBy)
                .SetProperty(x => x.UpdatedAt, actionDTO.UpdatedAt)
                .SetProperty(x => x.DraftedBy, actionDTO.DraftedBy)
                .SetProperty(x => x.DraftedAt, actionDTO.DraftedAt));

                ActionTypeAudit audit = new();
                audit.ActionTypeId = masterPUT.Id;
                audit.LanguageId = masterPUT.LanguageId;
                audit.ExportTypeId = masterPUT.ExportTypeId;
                audit.ExportTo = masterPUT.ExportTo;
                audit.SourceURL = masterPUT.SourceURL;
                audit.Name = masterPUT.Name;
                audit.Description = masterPUT.Description;
                audit.Browser = masterPUT.Browser;
                audit.Location = masterPUT.Location;
                audit.DeviceIP = masterPUT.DeviceIP;
                audit.LocationURL = masterPUT.LocationURL;
                audit.DeviceName = masterPUT.DeviceName;
                audit.Latitude = masterPUT.Latitude;
                audit.Longitude = masterPUT.Longitude;
                audit.ActionBy = masterPUT.ActionBy;
                audit.ActionAt = DateTime.Now;

                await context.ActionTypeAudits.AddAsync(audit);
                await context.SaveChangesAsync();
                await transaction.CommitAsync();

                requestResponse = new()
                {
                    StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
                    IsSuccess = true,
                    Message = ResponseMessage.UpdateSuccess,
                    Data = masterPUT
                };
            }

            else
            {
                requestResponse = new()
                {
                    StatusCode = $"{HTTPStatusCode.Conflict} {HTTPStatusCode.StatusCode409}",
                    IsSuccess = false,
                    Message = ResponseMessage.RecordExists
                };
            }

            return requestResponse;
        }

        catch
        {
            requestResponse = new()
            {
                StatusCode = $"{HTTPStatusCode.BadRequest} {HTTPStatusCode.StatusCode400}",
                IsSuccess = false,
                Message = ResponseMessage.WrongDataInput
            };

            return requestResponse;
        }
    }
}
