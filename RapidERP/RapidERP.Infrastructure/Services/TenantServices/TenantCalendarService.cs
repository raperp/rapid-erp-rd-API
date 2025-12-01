using Microsoft.EntityFrameworkCore;
using RapidERP.Application.DTOs.Shared;
using RapidERP.Application.DTOs.TenantDTOs.TenantCalendarDTOs;
using RapidERP.Application.Interfaces;
using RapidERP.Application.Interfaces.Tenant;
using RapidERP.Domain.Entities.TenantModels;
using RapidERP.Domain.Utilities;
using RapidERP.Infrastructure.Data;

namespace RapidERP.Infrastructure.Services.TenantServices;

public class TenantCalendarService(RapidERPDbContext context, IShared shared) : ITenantCalendar
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
                await context.SaveChangesAsync();

                TenantHistory audit = new();
                audit.TenantId = masterPOST.TenantId;
                audit.MenuModuleId = masterPOST.MenuModuleId;
                audit.CountryId = masterPOST.CountryId;
                audit.StateId = masterPOST.StateId;
                audit.LanguageId = masterPOST.LanguageId;
                audit.CalendarId = masterPOST.CalendarId;
                audit.ActionTypeId = masterPOST.ActionTypeId;
                audit.ExportTypeId = masterPOST.ExportTypeId;
                audit.ExportTo = masterPOST.ExportTo;
                audit.SourceURL = masterPOST.SourceURL;
                audit.DefaultCalendarId = masterPOST.DefaultCalendarId;
                audit.Browser = masterPOST.Browser;
                audit.Location = masterPOST.Location;
                audit.DeviceIP = masterPOST.DeviceIP;
                audit.LocationURL = masterPOST.LocationURL;
                audit.DeviceName = masterPOST.DeviceName;
                audit.Latitude = masterPOST.Latitude;
                audit.Longitude = masterPOST.Longitude;
                audit.ActionBy = masterPOST.ActionBy;
                audit.ActionAt = DateTime.Now;

                await context.TenantHistories.AddAsync(audit);
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

    public async Task<RequestResponse> GetAll(int skip, int take)
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

    public async Task<RequestResponse> GetHistory(int skip, int take)
    {
        try
        {
            var data = (from th in context.TenantHistories
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

            TenantHistory audit = new();
            audit.TenantId = masterPUT.TenantId;
            audit.MenuModuleId = masterPUT.MenuModuleId;
            audit.CountryId = masterPUT.CountryId;
            audit.StateId = masterPUT.StateId;
            audit.LanguageId = masterPUT.LanguageId;
            audit.CalendarId = masterPUT.CalendarId;
            audit.ActionTypeId = masterPUT.ActionTypeId;
            audit.ExportTypeId = masterPUT.ExportTypeId;
            audit.ExportTo = masterPUT.ExportTo;
            audit.SourceURL = masterPUT.SourceURL;
            audit.DefaultCalendarId = masterPUT.DefaultCalendarId;
            audit.Browser = masterPUT.Browser;
            audit.Location = masterPUT.Location;
            audit.DeviceIP = masterPUT.DeviceIP;
            audit.LocationURL = masterPUT.LocationURL;
            audit.DeviceName = masterPUT.DeviceName;
            audit.Latitude = masterPUT.Latitude;
            audit.Longitude = masterPUT.Longitude;
            audit.ActionBy = masterPUT.ActionBy;
            audit.ActionAt = DateTime.Now;

            await context.TenantHistories.AddAsync(audit);
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
