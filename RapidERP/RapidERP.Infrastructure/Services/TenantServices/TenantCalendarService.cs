using Microsoft.EntityFrameworkCore;
using RapidERP.Application.DTOs.TenantDTOs.TenantCalendarDTOs;
using RapidERP.Application.Interfaces;
using RapidERP.Application.Interfaces.Tenant;
using RapidERP.Domain.Entities.TenantModels;
using RapidERP.Domain.Utilities;
using RapidERP.Infrastructure.Data;

namespace RapidERP.Infrastructure.Services.TenantServices;

public class TenantCalendarService(RapidERPDbContext context, ISharedService shared) : ITenantCalendarService
{
    RequestResponse requestResponse { get; set; }

    public async Task<RequestResponse> CreateBulk(List<TenantCalendarPOST> masterPOSTs)
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

    public async Task<RequestResponse> CreateSingle(TenantCalendarPOST masterPOST)
    {
        try
        {
            await using var transaction = await context.Database.BeginTransactionAsync();
            //var isExists = await context.Tenants.AsNoTracking().AnyAsync(x => x.Name == masterPOST.Name);

            //if (isExists == false)
            //{
                TenantCalendar masterData = new();
                masterData.TenantId = masterPOST.TenantId;
                masterData.CalendarId = masterPOST.CalendarId;
                masterData.DefaultCalendarId = masterPOST.DefaultCalendarId;

                await context.TenantCalendars.AddAsync(masterData);
                //await context.SaveChangesAsync();

                TenantHistory history = new();
                history.TenantId = masterPOST.TenantId;
                history.MenuModuleId = masterPOST.MenuModuleId;
                history.CountryId = masterPOST.CountryId;
                history.StateId = masterPOST.StateId;
                history.LanguageId = masterPOST.LanguageId;
                history.CalendarId = masterPOST.CalendarId;
                history.ActionTypeId = masterPOST.ActionTypeId;
                history.ExportTypeId = masterPOST.ExportTypeId;
                history.ExportTo = masterPOST.ExportTo;
                history.SourceURL = masterPOST.SourceURL;
                history.DefaultCalendarId = masterPOST.DefaultCalendarId;
                history.Browser = masterPOST.Browser;
                history.Location = masterPOST.Location;
                history.DeviceIP = masterPOST.DeviceIP;
                history.LocationURL = masterPOST.LocationURL;
                history.DeviceName = masterPOST.DeviceName;
                history.Latitude = masterPOST.Latitude;
                history.Longitude = masterPOST.Longitude;
                history.ActionBy = masterPOST.ActionBy;
                history.ActionAt = DateTime.Now;

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

    public async Task<RequestResponse> GetAll(int skip, int take, int pageSize)
    {
        try
        {
            var data = (from tc in context.TenantCalendars
                        join t in context.Tenants on tc.TenantId equals t.Id
                        select new
                        {
                            tc.Id,
                            Tenant = t.Name,
                            tc.Name,
                            tc.CalendarId,
                            tc.DefaultCalendarId,
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
                        join mm in context.MenuModules on th.MenuModuleId equals mm.Id
                        join c in context.Countries on th.CountryId equals c.Id
                        join s in context.States on th.StateId equals s.Id
                        join l in context.Languages on th.LanguageId equals l.Id
                        join at in context.ActionTypes on th.ActionTypeId equals at.Id
                        join et in context.ExportTypes on th.ExportTypeId equals et.Id
                        select new
                        {
                            th.Id,
                            Tenant = t.Name,
                            MenuModule = mm.Name,
                            Country = c.Name,
                            State = s.Name,
                            Language = l.Name,
                            Action = at.Name,
                            ExportMedia = et.Name,
                            th.ExportTo,
                            th.SourceURL,
                            th.CalendarId,
                            th.DefaultCalendarId,
                            th.Browser,
                            th.Location,
                            th.DeviceIP,
                            th.LocationURL,
                            th.DeviceName,
                            th.Latitude,
                            th.Longitude,
                            th.ActionBy,
                            th.ActionAt
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

    public Task<dynamic> GetSingle(int id)
    {
        throw new NotImplementedException();
    }

    public Task<dynamic> SoftDelete(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<RequestResponse> Update(TenantCalendarPUT masterPUT)
    {
        try
        {
            await using var transaction = await context.Database.BeginTransactionAsync();
            //var isExists = await context.Tenants.AsNoTracking().AnyAsync(x => x.Name == masterPUT.Name && x.Id != masterPUT.Id);

            //if (isExists == false)
            //{
                await context.TenantCalendars.Where(x => x.Id == masterPUT.Id).ExecuteUpdateAsync(x => x
                .SetProperty(x => x.TenantId, masterPUT.TenantId)
                .SetProperty(x => x.CalendarId, masterPUT.CalendarId)
                .SetProperty(x => x.DefaultCalendarId, masterPUT.DefaultCalendarId));

            TenantHistory history = new();
            history.TenantId = masterPUT.TenantId;
            history.MenuModuleId = masterPUT.MenuModuleId;
            history.CountryId = masterPUT.CountryId;
            history.StateId = masterPUT.StateId;
            history.LanguageId = masterPUT.LanguageId;
            history.CalendarId = masterPUT.CalendarId;
            history.ActionTypeId = masterPUT.ActionTypeId;
            history.ExportTypeId = masterPUT.ExportTypeId;
            history.ExportTo = masterPUT.ExportTo;
            history.SourceURL = masterPUT.SourceURL;
            history.DefaultCalendarId = masterPUT.DefaultCalendarId;
            history.Browser = masterPUT.Browser;
            history.Location = masterPUT.Location;
            history.DeviceIP = masterPUT.DeviceIP;
            history.LocationURL = masterPUT.LocationURL;
            history.DeviceName = masterPUT.DeviceName;
            history.Latitude = masterPUT.Latitude;
            history.Longitude = masterPUT.Longitude;
            history.ActionBy = masterPUT.ActionBy;
            history.ActionAt = DateTime.Now;

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
            //    requestResponse = new()
            //    {
            //        StatusCode = $"{HTTPStatusCode.Conflict} {HTTPStatusCode.StatusCode409}",
            //        IsSuccess = false,
            //        Message = ResponseMessage.RecordExists
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
}
