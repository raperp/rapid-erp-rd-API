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
                masterData.StatusTypeId = masterPOST.StatusTypeId;
                masterData.Name = masterPOST.Name;
                masterData.Description = masterPOST.Description;
                //masterData.CreatedBy = masterPOST.CreatedBy;
                masterData.CreatedAt = DateTime.Now;

                await context.ActionTypes.AddAsync(masterData);
                await context.SaveChangesAsync();

                ActionTypeAudit audit = new();
                audit.ActionTypeId = masterData.Id;
                audit.LanguageId = masterPOST.LanguageId;
                audit.Name = masterPOST.Name;
                audit.Description = masterPOST.Description;
                //audit.IsDefault = masterPOST.IsDefault;
                audit.ExportTypeId = masterPOST.ExportTypeId;
                audit.ExportTo = masterPOST.ExportTo;
                audit.SourceURL = masterPOST.SourceURL;
                audit.Browser = masterPOST.Browser;
                audit.DeviceName = masterPOST.DeviceName;
                audit.Location = masterPOST.Location;
                audit.DeviceIP = masterPOST.DeviceIP;
                //audit.GoogleMapUrl = masterPOST.GoogleMapUrl;
                audit.Latitude = masterPOST.Latitude;
                audit.Longitude = masterPOST.Longitude;
                //audit.ActionBy = masterPOST.CreatedBy;
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
                        join st in context.StatusTypes on at.StatusTypeId equals st.Id
                        select new
                        {
                            at.Id,
                            Language = l.Name,
                            StatusType = st.Name,
                            at.Name,
                            at.Description,
                            at.CreatedBy,
                            at.CreatedAt
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
                        //join et in context.ExportTypes on ata.ExportTypeId equals et.Id
                        select new
                        {
                            ata.Id,
                            ActionType = at.Name,
                            Language = l.Name,
                            ata.Name,
                            ata.Description,
                            //ExportType = et.Name,
                            ata.ExportTo,
                            ata.SourceURL,
                            //ata.IsDefault,
                            ata.Browser,
                            ata.Location,
                            ata.DeviceIP,
                            //ata.GoogleMapUrl,
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

    public Task<RequestResponse> SoftDeleteRestore(SoftDeleteRestore softDeleteRestore)
    {
        throw new NotImplementedException();
    }

    public async Task<RequestResponse> Update(ActionTypePUT masterPUT)
    {
        try
        {
            await using var transaction = await context.Database.BeginTransactionAsync();
            var isExists = await context.ActionTypes.AsNoTracking().AnyAsync(x => x.Name == masterPUT.Name && x.Id != masterPUT.Id);

            if (isExists == false)
            {
                await context.ActionTypes.Where(x => x.Id == masterPUT.Id).ExecuteUpdateAsync(x => x
                .SetProperty(x => x.LanguageId, masterPUT.LanguageId)
                .SetProperty(x => x.StatusTypeId, masterPUT.StatusTypeId)
                .SetProperty(x => x.Name, masterPUT.Name)
                .SetProperty(x => x.Description, masterPUT.Description)
                //.SetProperty(x => x.UpdatedBy, masterPUT.UpdatedBy)
                .SetProperty(x => x.UpdatedAt, DateTime.Now));

                ActionTypeAudit audit = new();
                audit.ActionTypeId = masterPUT.Id;
                audit.LanguageId = masterPUT.LanguageId;
                audit.Name = masterPUT.Name;
                audit.Description = masterPUT.Description;
                //audit.IsDefault = masterPUT.IsDefault;
                audit.ExportTypeId = masterPUT.ExportTypeId;
                audit.ExportTo = masterPUT.ExportTo;
                audit.SourceURL = masterPUT.SourceURL;
                audit.Browser = masterPUT.Browser;
                audit.DeviceName = masterPUT.DeviceName;
                audit.Location = masterPUT.Location;
                audit.DeviceIP = masterPUT.DeviceIP;
                //audit.GoogleMapUrl = masterPUT.GoogleMapUrl;
                audit.Latitude = masterPUT.Latitude;
                audit.Longitude = masterPUT.Longitude;
                //audit.ActionBy = masterPUT.UpdatedBy;
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
