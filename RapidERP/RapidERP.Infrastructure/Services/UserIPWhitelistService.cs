using Microsoft.EntityFrameworkCore;
using RapidERP.Application.DTOs.Shared;
using RapidERP.Application.DTOs.UserIPWhitelistDTOs;
using RapidERP.Application.Interfaces;
using RapidERP.Domain.Entities.UserIPWhitelistModels;
using RapidERP.Domain.Utilities;
using RapidERP.Infrastructure.Data;

namespace RapidERP.Infrastructure.Services;

public class UserIPWhitelistService(RapidERPDbContext context, ISharedService shared) : IUserIPWhitelistService
{
    RequestResponse requestResponse { get; set; }

    public async Task<RequestResponse> CreateBulk(List<UserIPWhitelistPOST> masterPOSTs)
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

    public async Task<RequestResponse> CreateSingle(UserIPWhitelistPOST masterPOST)
    {
        try
        {
            await using var transaction = await context.Database.BeginTransactionAsync();
            var isExists = await context.UserIPWhitelists.AsNoTracking().AnyAsync(x => x.UserId == masterPOST.UserId || x.IPAddress == masterPOST.IPAddress);

            if (isExists == false)
            {
                UserIPWhitelist masterData = new();
                //masterData.StatusTypeId = masterPOST.StatusTypeId;
                masterData.UserId = masterPOST.UserId;
                masterData.IPAddress = masterPOST.IPAddress;

                await context.UserIPWhitelists.AddAsync(masterData);
                await context.SaveChangesAsync();

                UserIPWhitelistHistory history = new();
                history.UserIPWhitelistId = masterData.Id;
                history.ActionTypeId = masterPOST.ActionTypeId;
                //history.ExportTypeId = masterPOST.ExportTypeId;
                history.UserId = masterPOST.UserId;
                history.IPAddress = masterPOST.IPAddress;
                //history.ExportTo = masterPOST.ExportTo;
                //history.SourceURL = masterPOST.SourceURL;
                //history.Browser = masterPOST.Browser;
                //history.Location = masterPOST.Location;
                //history.DeviceIP = masterPOST.DeviceIP;
                //history.LocationURL = masterPOST.LocationURL;
                //history.DeviceName = masterPOST.DeviceName;
                //history.Latitude = masterPOST.Latitude;
                //history.Longitude = masterPOST.Longitude;
                //history.ActionBy = masterPOST.ActionBy;
                //history.ActionAt = DateTime.Now;
                
                await context.UserIPWhitelistHistory.AddAsync(history);
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
                    Message = $"{ResponseMessage.RecordExists} {masterPOST.IPAddress}"
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

    public Task<RequestResponse> Delete(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<RequestResponse> GetAll(int skip, int take, int pageSize)
    {
        try
        {
            GetAllDTO result = new();

            var data = (from uiw in context.UserIPWhitelists
                        join u in context.Users on uiw.UserId equals u.Id
                        //join st in context.StatusTypes on uiw.StatusTypeId equals st.Id
                        select new
                        {
                            uiw.Id,
                            User = u.Name,
                            uiw.IPAddress,
                            //Status = st.Name
                        }).AsNoTracking().AsQueryable();

            if (skip == 0 || take == 0)
            {
                result.Count = await shared.GetCounts<UserIPWhitelist>(pageSize);
                result.Data = await data.ToListAsync();

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
                result.Count = await shared.GetCounts<UserIPWhitelist>(pageSize);
                result.Data = await data.Skip(skip).Take(take).ToListAsync();

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

    public Task<RequestResponse> GetAll(int skip, int take)
    {
        throw new NotImplementedException();
    }

    public async Task<RequestResponse> GetHistory(int skip, int take, int pageSize)
    {
        try
        {
            var data = (from uiwh in context.UserIPWhitelistHistory
                        join uiw in context.UserIPWhitelists on uiwh.UserId equals uiw.Id
                        join u in context.Users on uiwh.UserId equals u.Id
                        //join et in context.ExportTypes on uiwh.ExportTypeId equals et.Id
                        join at in context.ActionTypes on uiwh.ActionTypeId equals at.Id
                        select new
                        {
                            uiwh.Id,
                            User = u.Name,
                            IP = uiw.IPAddress,
                            //ExportType = et.Name,
                            ActionType = at.Name,
                            uiwh.IPAddress,
                            //uiwh.ExportTo,
                            //uiwh.SourceURL,
                            //uiwh.Browser,
                            //uiwh.Location,
                            //uiwh.DeviceIP,
                            //uiwh.LocationURL,
                            //uiwh.DeviceName,
                            //uiwh.Latitude,
                            //uiwh.Longitude,
                            //uiwh.ActionBy,
                            //uiwh.ActionAt
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
        var result = await shared.GetSingle<UserIPWhitelist>(id);
        return result;
    }

    public Task<RequestResponse> GetTemplate()
    {
        throw new NotImplementedException();
    }

    public async Task<dynamic> SoftDelete(int id)
    {
        var result = await shared.SoftDelete<UserIPWhitelist>(id);
        return result;
    }

    public async Task<RequestResponse> Update(UserIPWhitelistPUT masterPUT)
    {
        try
        {
            await using var transaction = await context.Database.BeginTransactionAsync();
            var isExists = await context.UserIPWhitelists.AsNoTracking().AnyAsync(x => x.IPAddress == masterPUT.IPAddress && x.Id != masterPUT.Id);

            if (isExists == false)
            {
                await context.UserIPWhitelists.Where(x => x.Id == masterPUT.Id).ExecuteUpdateAsync(x => x
                 .SetProperty(x => x.UserId, masterPUT.UserId)
                 //.SetProperty(x => x.StatusTypeId, masterPUT.StatusTypeId)
                 .SetProperty(x => x.IPAddress, masterPUT.IPAddress));

                UserIPWhitelistHistory history = new();
                history.UserIPWhitelistId = masterPUT.Id;
                history.ActionTypeId = masterPUT.ActionTypeId;
                //history.ExportTypeId = masterPUT.ExportTypeId;
                history.UserId = masterPUT.UserId;
                history.IPAddress = masterPUT.IPAddress;
                //history.ExportTo = masterPUT.ExportTo;
                //history.SourceURL = masterPUT.SourceURL;
                //history.Browser = masterPUT.Browser;
                //history.Location = masterPUT.Location;
                //history.DeviceIP = masterPUT.DeviceIP;
                //history.LocationURL = masterPUT.LocationURL;
                //history.DeviceName = masterPUT.DeviceName;
                //history.Latitude = masterPUT.Latitude;
                //history.Longitude = masterPUT.Longitude;
                //history.ActionBy = masterPUT.ActionBy;
                //history.ActionAt = DateTime.Now;

                await context.UserIPWhitelistHistory.AddAsync(history);
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

    public Task<RequestResponse> UpdateStatus(UpdateStatus updateStatus)
    {
        throw new NotImplementedException();
    }

    Task<RequestResponse> IBase<UserIPWhitelistPOST, UserIPWhitelistPUT>.GetSingle(int id)
    {
        throw new NotImplementedException();
    }

   
}
