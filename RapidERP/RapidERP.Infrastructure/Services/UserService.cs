using Microsoft.EntityFrameworkCore;
using RapidERP.Application.DTOs.Shared;
using RapidERP.Application.DTOs.UserDTOs;
using RapidERP.Application.Interfaces;
using RapidERP.Domain.Entities.UserModels;
using RapidERP.Domain.Utilities;
using RapidERP.Infrastructure.Data;

namespace RapidERP.Infrastructure.Services;

public class UserService(RapidERPDbContext context, IShared shared) : IUser
{
    RequestResponse requestResponse { get; set; }

    public async Task<RequestResponse> CreateBulk(List<UserPOST> masterPOSTs)
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

    public async Task<RequestResponse> CreateSingle(UserPOST masterPOST)
    {
        try
        {
            await using var transaction = await context.Database.BeginTransactionAsync();
            var isExists = await context.Users.AsNoTracking().AnyAsync(x => x.UserName == masterPOST.UserName || x.Email == masterPOST.Email || x.Mobile == masterPOST.Mobile);

            if (isExists == false)
            {
                User masterData = new();
                masterData.Name = masterPOST.Name;
                masterData.UserName = masterPOST.UserName;
                masterData.Email = masterPOST.Email;
                masterData.Mobile = masterPOST.Mobile;
                masterData.Address = masterPOST.Address;
                masterData.Password = masterPOST.Password;
                masterData.StatusTypeId = masterPOST.StatusTypeId;

                await context.Users.AddAsync(masterData);
                await context.SaveChangesAsync();

                UserHistory history = new();
                history.Name = masterPOST.Name;
                history.UserName = masterPOST.UserName;
                history.Email = masterPOST.Email;
                history.Mobile = masterPOST.Mobile;
                history.Address = masterPOST.Address;
                history.Password = masterPOST.Password;
                history.UserId = masterData.Id;
                //history.StatusTypeId = masterPOST.StatusTypeId;
                history.ActionTypeId = masterPOST.ActionTypeId;
                history.ExportTypeId = masterPOST.ExportTypeId;
                history.ExportTo = masterPOST.ExportTo;
                history.SourceURL = masterPOST.SourceURL;
                //history.IsDefault = masterPOST.IsDefault;
                history.Browser = masterPOST.Browser;
                history.DeviceName = masterPOST.DeviceName;
                history.Location = masterPOST.Location;
                history.DeviceIP = masterPOST.DeviceIP;
                //history.GoogleMapUrl = masterPOST.GoogleMapUrl;
                history.Latitude = masterPOST.Latitude;
                history.Longitude = masterPOST.Longitude;
                //history.ActionBy = masterPOST.CreatedBy;
                history.ActionAt = DateTime.Now;

                await context.UserHistory.AddAsync(history);
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
            var ishistoryExists = await context.UserHistory.AsNoTracking().AnyAsync(x => x.UserId == id);

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
                await context.UserHistory.Where(x => x.UserId == id).ExecuteDeleteAsync();
            }

            var isExists = await context.Users.AsNoTracking().AnyAsync(x => x.Id == id);

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
                await context.Users.Where(x => x.Id == id).ExecuteDeleteAsync();
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
            GetAllDTO result = new();

            var data = (from u in context.Users
                        join st in context.StatusTypes on u.StatusTypeId equals st.Id
                        select new
                        {
                            u.Id,
                            u.Name,
                            u.UserName,
                            u.Email,
                            u.Mobile,
                            u.OTP,
                            StatusType = st.Name,
                            Status = st.Name
                        }).AsNoTracking().AsQueryable();

            if (skip == 0 || take == 0)
            {
                result.Count = await shared.GetCounts<User>();
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
                result.Count = await shared.GetCounts<User>();
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

    public async Task<RequestResponse> GetHistory(int skip, int take)
    {
        try
        {
            var data = (from ua in context.UserHistory
                        join u in context.Users on ua.UserId equals u.Id
                        //join et in context.ExportTypes on aa.ExportTypeId equals et.Id
                        join at in context.ActionTypes on ua.ActionTypeId equals at.Id
                        //join st in context.StatusTypes on ua.StatusTypeId equals st.Id
                        select new
                        {
                            ua.Id,
                            User = u.Name,
                            ua.Name,
                            ua.UserName,
                            ua.Email,
                            ua.Mobile,
                            ua.Address,
                            //ExportType = et.Name,
                            ActionType = at.Name,
                            //StatusType = st.Name,
                            ua.ExportTo,
                            ua.SourceURL,
                            //ua.IsDefault,
                            ua.Browser,
                            ua.DeviceName,
                            ua.Location,
                            ua.DeviceIP,
                            //ua.GoogleMapUrl,
                            ua.Latitude,
                            ua.Longitude,
                            ua.ActionBy,
                            ua.ActionAt
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
        var result = await shared.GetSingle<User>(id);
        return result;
    }

    public Task<dynamic> SoftDelete(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<RequestResponse> Update(UserPUT masterPUT)
    {
        try
        {
            await using var transaction = await context.Database.BeginTransactionAsync();
            var isExists = await context.Users.AsNoTracking().AnyAsync(x => x.Name == masterPUT.Name && x.Id != masterPUT.Id);

            if (isExists == false)
            {
                await context.Users.Where(x => x.Id == masterPUT.Id).ExecuteUpdateAsync(x => x
                .SetProperty(x => x.Name, masterPUT.Name)
                .SetProperty(x => x.UserName, masterPUT.UserName)
                .SetProperty(x => x.Email, masterPUT.Email)
                .SetProperty(x => x.Mobile, masterPUT.Mobile)
                .SetProperty(x => x.Address, masterPUT.Address)
                .SetProperty(x => x.Password, masterPUT.Password));

                UserHistory history = new();
                history.Name = masterPUT.Name;
                history.UserName = masterPUT.UserName;
                history.Email = masterPUT.Email;
                history.Mobile = masterPUT.Mobile;
                history.Address = masterPUT.Address;
                history.Password = masterPUT.Password;
                history.UserId = masterPUT.Id;
                //history.StatusTypeId = masterPUT.StatusTypeId;
                history.ActionTypeId = masterPUT.ActionTypeId;
                history.ExportTypeId = masterPUT.ExportTypeId;
                history.ExportTo = masterPUT.ExportTo;
                history.SourceURL = masterPUT.SourceURL;
                //history.IsDefault = masterPUT.IsDefault;
                history.Browser = masterPUT.Browser;
                history.DeviceName = masterPUT.DeviceName;
                history.Location = masterPUT.Location;
                history.DeviceIP = masterPUT.DeviceIP;
                //history.GoogleMapUrl = masterPUT.GoogleMapUrl;
                history.Latitude = masterPUT.Latitude;
                history.Longitude = masterPUT.Longitude;
                //history.ActionBy = masterPUT.UpdatedBy;
                history.ActionAt = DateTime.Now;

                await context.UserHistory.AddAsync(history);
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
