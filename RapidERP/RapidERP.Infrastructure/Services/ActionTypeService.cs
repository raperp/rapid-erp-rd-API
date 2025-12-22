using Microsoft.EntityFrameworkCore;
using RapidERP.Application.DTOs.ActionTypeDTOs;
using RapidERP.Application.DTOs.Shared;
using RapidERP.Application.Interfaces;
using RapidERP.Domain.Entities.ActionTypeModels;
using RapidERP.Domain.Utilities;
using RapidERP.Infrastructure.Data;

namespace RapidERP.Infrastructure.Services;

public class ActionTypeService(RapidERPDbContext context, ISharedService shared) : IActionTypeService
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

                await context.ActionTypes.AddAsync(masterData);
                //await context.SaveChangesAsync();

                ActionTypeHistory history = new();
                history.ActionTypeId = masterData.Id;
                history.LanguageId = masterPOST.LanguageId;
                history.ExportTypeId = masterPOST.ExportTypeId;
                history.ExportTo = masterPOST.ExportTo;
                history.SourceURL = masterPOST.SourceURL;
                history.Name = masterPOST.Name;
                history.Description = masterPOST.Description;
                history.Browser = masterPOST.Browser;
                history.Location = masterPOST.Location;
                history.DeviceIP = masterPOST.DeviceIP;
                history.LocationURL = masterPOST.LocationURL;
                history.DeviceName = masterPOST.DeviceName;
                history.Latitude = masterPOST.Latitude;
                history.Longitude = masterPOST.Longitude;
                history.ActionBy = masterPOST.ActionBy;
                history.ActionAt = DateTime.Now;

                await context.ActionTypeHistory.AddAsync(history);
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
            var ishistoryExists = await context.ActionTypeHistory.AsNoTracking().AnyAsync(x => x.ActionTypeId == id);

            if (ishistoryExists == false)
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
                await context.ActionTypeHistory.Where(x => x.ActionTypeId == id).ExecuteDeleteAsync();
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

    public async Task<RequestResponse> GetAll(int skip, int take, int pageSize)
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
                            at.Description
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

    public async Task<RequestResponse> GetHistory(int skip, int take, int pageSize)
    {
        try
        {
            var data = (from ath in context.ActionTypeHistory
                        join at in context.ActionTypes on ath.ActionTypeId equals at.Id
                        join l in context.Languages on ath.LanguageId equals l.Id
                        join et in context.ExportTypes on ath.ExportTypeId equals et.Id
                        select new
                        {
                            ath.Id,
                            ActionType = at.Name,
                            Language = l.Name,
                            ExportType = et.Name,
                            ath.ExportTo,
                            ath.SourceURL,
                            ath.Name,
                            ath.Description,
                            ath.Browser,
                            ath.Location,
                            ath.DeviceIP,
                            ath.LocationURL,
                            ath.DeviceName,
                            ath.Latitude,
                            ath.Longitude,
                            ath.ActionBy,
                            ath.ActionAt
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

    public Task<RequestResponse> GetTemplate()
    {
        throw new NotImplementedException();
    }

    public async Task<dynamic> SoftDelete(int id)
    {
        var result = "Not Applicable";
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
                .SetProperty(x => x.Description, masterPUT.Description));

                ActionTypeHistory history = new();
                history.ActionTypeId = masterPUT.Id;
                history.LanguageId = masterPUT.LanguageId;
                history.ExportTypeId = masterPUT.ExportTypeId;
                history.ExportTo = masterPUT.ExportTo;
                history.SourceURL = masterPUT.SourceURL;
                history.Name = masterPUT.Name;
                history.Description = masterPUT.Description;
                history.Browser = masterPUT.Browser;
                history.Location = masterPUT.Location;
                history.DeviceIP = masterPUT.DeviceIP;
                history.LocationURL = masterPUT.LocationURL;
                history.DeviceName = masterPUT.DeviceName;
                history.Latitude = masterPUT.Latitude;
                history.Longitude = masterPUT.Longitude;
                history.ActionBy = masterPUT.ActionBy;
                history.ActionAt = DateTime.Now;

                await context.ActionTypeHistory.AddAsync(history);
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
