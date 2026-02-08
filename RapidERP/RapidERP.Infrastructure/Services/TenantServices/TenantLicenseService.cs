using Microsoft.EntityFrameworkCore;
using RapidERP.Application.DTOs.TenantDTOs.TenantLicenseDTOs;
using RapidERP.Application.Interfaces;
using RapidERP.Application.Interfaces.Tenant;
using RapidERP.Domain.Entities.TenantModels;
using RapidERP.Domain.Utilities;
using RapidERP.Infrastructure.Data;

namespace RapidERP.Infrastructure.Services.TenantServices;

public class TenantLicenseService(RapidERPDbContext context, ISharedService shared) : ITenantLicenseService
{
    RequestResponse requestResponse { get; set; }

    public async Task<RequestResponse> CreateBulk(List<TenantLicensePOST> masterPOSTs)
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

    public async Task<RequestResponse> CreateSingle(TenantLicensePOST masterPOST)
    {
        try
        {
            await using var transaction = await context.Database.BeginTransactionAsync();
            //var isExists = await context.Tenants.AsNoTracking().AnyAsync(x => x.Name == masterPOST.Name);

            //if (isExists == false)
            //{
                TenantLicense masterData = new();
                masterData.TenantId = masterPOST.TenantId;
                masterData.LicenseNumber = masterPOST.LicenseNumber;
                masterData.LimitUsers = masterPOST.LimitUsers;
                masterData.ERPPlan = masterPOST.ERPPlan;
                masterData.IssueAt = masterPOST.IssueAt;
                masterData.ValidityDays = masterPOST.ValidityDays;
                masterData.ExpiryAt = masterPOST.ExpiryAt;
                masterData.ReminderAt = masterPOST.ReminderAt;

                await context.TenantLicenses.AddAsync(masterData);
                //await context.SaveChangesAsync();

            TenantHistory history = new();
            history.TenantId = masterPOST.TenantId;
            //history.MenuModuleId = masterPOST.MenuModuleId;
            history.CountryId = masterPOST.CountryId;
            history.StateId = masterPOST.StateId;
            //history.LanguageId = masterPOST.LanguageId;
            history.CalendarId = masterPOST.CalendarId;
            history.ActionTypeId = masterPOST.ActionTypeId;
            //history.ExportTypeId = masterPOST.ExportTypeId;
            //history.ExportTo = masterPOST.ExportTo;
            //history.SourceURL = masterPOST.SourceURL;
            history.LicenseNumber = masterPOST.LicenseNumber;
            history.LimitUsers = masterPOST.LimitUsers;
            history.ERPPlan = masterPOST.ERPPlan;
            history.IssueAt = masterPOST.IssueAt;
            history.ValidityDays = masterPOST.ValidityDays;
            history.ExpiryAt = masterPOST.ExpiryAt;
            history.ReminderAt = masterPOST.ReminderAt;
            //history.Browser = masterPOST.Browser;
            //history.Location = masterPOST.Location;
            //history.DeviceIP = masterPOST.DeviceIP;
            //history.LocationURL = masterPOST.LocationURL;
            //history.DeviceName = masterPOST.DeviceName;
            //history.Latitude = masterPOST.Latitude;
            //history.Longitude = masterPOST.Longitude;
            //history.ActionBy = masterPOST.ActionBy;
            //history.ActionAt = DateTime.Now;

            await context.TenantHistory.AddAsync(history);
            await context.SaveChangesAsync();
            await transaction.CommitAsync();

                requestResponse = new()
                {
                    StatusCode = $"{HTTPStatusCode.Created} {HTTPStatusCode.StatusCode201}",
                    IsSuccess = true,
                    Message = ResponseMessage.CreateSuccess,
                    Data = masterPOST
                };
            //}

            //else
            //{
            //    requestResponse = new()
            //    {
            //        StatusCode = $"{HTTPStatusCode.Conflict} {HTTPStatusCode.StatusCode409}",
            //        IsSuccess = false,
            //        Message = $"{ResponseMessage.RecordExists} {masterPOST.Name}"
            //    };
            //}

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
            var data = (from tl in context.TenantLicenses
                        join t in context.Tenants on tl.TenantId equals t.Id
                        select new
                        {
                            tl.Id,
                            Tenant = t.Name,
                            tl.LicenseNumber,
                            tl.LimitUsers,
                            tl.ERPPlan,
                            tl.IssueAt,
                            tl.ValidityDays,
                            tl.ExpiryAt,
                            tl.ReminderAt
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
            var data = (from th in context.TenantHistory
                        join t in context.Tenants on th.TenantId equals t.Id
                        //join mm in context.MenuModules on th.MenuModuleId equals mm.Id
                        join c in context.Countries on th.CountryId equals c.Id
                        join st in context.States on th.StateId equals st.Id
                        //join l in context.Languages on th.LanguageId equals l.Id
                        join at in context.ActionTypes on th.ActionTypeId equals at.Id
                        //join et in context.ExportTypes on th.ExportTypeId equals et.Id
                        select new
                        {
                            th.Id,
                            Tenant = t.Name,
                            //MenuModule = mm.Name,
                            Country = c.Name,
                            State = st.Name,
                            //Language = l.Name,
                            ActionType = at.Name,
                            //ExportType = et.Name,
                            //th.ExportTo,
                            //th.SourceURL,
                            th.Name,
                            th.Contact,
                            th.Phone,
                            th.Mobile,
                            th.Address,
                            th.Email,
                            th.Website,
                            //th.Browser,
                            //th.Location,
                            //th.DeviceIP,
                            //th.LocationURL,
                            //th.DeviceName,
                            //th.Latitude,
                            //th.Longitude,
                            //th.ActionBy,
                            //th.ActionAt
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
        var result = await shared.GetSingle<TenantLicense>(id);
        return result;
    }

    public Task<RequestResponse> GetTemplate()
    {
        throw new NotImplementedException();
    }

    public Task<dynamic> SoftDelete(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<RequestResponse> Update(TenantLicensePUT masterPUT)
    {
        try
        {
            await using var transaction = await context.Database.BeginTransactionAsync();
            //var isExists = await context.Tenants.AsNoTracking().AnyAsync(x => x.Name == masterPUT.Name && x.Id != masterPUT.Id);

            //if (isExists == false)
            //{
                await context.TenantLicenses.Where(x => x.Id == masterPUT.Id).ExecuteUpdateAsync(x => x
                .SetProperty(x => x.TenantId, masterPUT.TenantId)
                .SetProperty(x => x.LicenseNumber, masterPUT.LicenseNumber)
                .SetProperty(x => x.LimitUsers, masterPUT.LimitUsers)
                .SetProperty(x => x.ERPPlan, masterPUT.ERPPlan)
                .SetProperty(x => x.IssueAt, masterPUT.IssueAt)
                .SetProperty(x => x.ValidityDays, masterPUT.ValidityDays)
                .SetProperty(x => x.ExpiryAt, masterPUT.ExpiryAt)
                .SetProperty(x => x.ReminderAt, masterPUT.ReminderAt));

            TenantHistory history = new();
            history.TenantId = masterPUT.TenantId;
            //history.MenuModuleId = masterPUT.MenuModuleId;
            history.CountryId = masterPUT.CountryId;
            history.StateId = masterPUT.StateId;
            //history.LanguageId = masterPUT.LanguageId;
            history.CalendarId = masterPUT.CalendarId;
            history.ActionTypeId = masterPUT.ActionTypeId;
            //history.ExportTypeId = masterPUT.ExportTypeId;
            //history.ExportTo = masterPUT.ExportTo;
            //history.SourceURL = masterPUT.SourceURL;
            history.LicenseNumber = masterPUT.LicenseNumber;
            history.LimitUsers = masterPUT.LimitUsers;
            history.ERPPlan = masterPUT.ERPPlan;
            history.IssueAt = masterPUT.IssueAt;
            history.ValidityDays = masterPUT.ValidityDays;
            history.ExpiryAt = masterPUT.ExpiryAt;
            history.ReminderAt = masterPUT.ReminderAt;
            //history.Browser = masterPUT.Browser;
            //history.Location = masterPUT.Location;
            //history.DeviceIP = masterPUT.DeviceIP;
            //history.LocationURL = masterPUT.LocationURL;
            //history.DeviceName = masterPUT.DeviceName;
            //history.Latitude = masterPUT.Latitude;
            //history.Longitude = masterPUT.Longitude;
            //history.ActionBy = masterPUT.ActionBy;
            //history.ActionAt = DateTime.Now;

            await context.TenantHistory.AddAsync(history);
            await context.SaveChangesAsync();
            await transaction.CommitAsync();

                requestResponse = new()
                {
                    StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
                    IsSuccess = true,
                    Message = ResponseMessage.UpdateSuccess,
                    Data = masterPUT
                };
            //}

            //else
            //{
                requestResponse = new()
                {
                    StatusCode = $"{HTTPStatusCode.Conflict} {HTTPStatusCode.StatusCode409}",
                    IsSuccess = false,
                    Message = ResponseMessage.RecordExists
                };
            //}

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
