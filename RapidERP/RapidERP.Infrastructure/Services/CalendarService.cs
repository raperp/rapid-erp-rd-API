using Microsoft.EntityFrameworkCore;
using RapidERP.Application.DTOs.CalendarDTOs;
using RapidERP.Application.DTOs.Shared;
using RapidERP.Application.Interfaces;
using RapidERP.Domain.Entities.CalendarModels;
using RapidERP.Domain.Utilities;
using RapidERP.Infrastructure.Data;

namespace RapidERP.Infrastructure.Services;

public class CalendarService(RapidERPDbContext context, ISharedService shared) : ICalendarService
{
    RequestResponse requestResponse { get; set; }

    public async Task<RequestResponse> CreateBulk(List<CalendarPOST> masterPOSTs)
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

    public async Task<RequestResponse> CreateSingle(CalendarPOST masterPOST)
    {
        try
        {
            await using var transaction = await context.Database.BeginTransactionAsync();
            var isExists = await context.Calendars.AsNoTracking().AnyAsync(x => x.Name == masterPOST.Name);

            if (isExists == false)
            {
                Calendar masterData = new();
                masterData.TenantId = masterPOST.TenantId;
                masterData.MenuModuleId = masterPOST.MenuModuleId;
                masterData.LanguageId = masterPOST.LanguageId;
                masterData.StatusTypeId = masterPOST.StatusTypeId;
                masterData.Code = masterPOST.Code;
                masterData.Name = masterPOST.Name;
                masterData.StartDate = masterPOST.StartDate;
                masterData.EndDate = masterPOST.EndDate;
                masterData.TotalMonth = masterPOST.TotalMonth;

                await context.Calendars.AddAsync(masterData);
                //await context.SaveChangesAsync();

                CalendarHistory history = new();
                history.CalendarId = masterData.Id;
                history.TenantId = masterPOST.TenantId;
                history.MenuModuleId = masterPOST.MenuModuleId;
                history.LanguageId = masterPOST.LanguageId;
                history.ActionTypeId = masterPOST.ActionTypeId;
                history.ExportTypeId = masterPOST.ExportTypeId;
                history.ExportTo = masterPOST.ExportTo;
                history.SourceURL = masterPOST.SourceURL;
                history.Code = masterPOST.Code;
                history.Name = masterPOST.Name;
                history.StartDate = masterPOST.StartDate;
                history.EndDate = masterPOST.EndDate;
                history.TotalMonth = masterPOST.TotalMonth;
                history.Browser = masterPOST.Browser;
                history.Location = masterPOST.Location;
                history.DeviceIP = masterPOST.DeviceIP;
                history.LocationURL = masterPOST.LocationURL;
                history.DeviceName = masterPOST.DeviceName;
                history.Latitude = masterPOST.Latitude;
                history.Longitude = masterPOST.Longitude;
                history.ActionBy = masterPOST.ActionBy;
                history.ActionAt = DateTime.Now;

                await context.CalendarHistory.AddAsync(history);
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

    public async Task<RequestResponse> GetAll(int skip, int take)
    {
        try
        {
            GetAllDTO result = new();

            var data = (from c in context.Calendars
                        join t in context.Tenants on c.TenantId equals t.Id
                        join mm in context.MenuModules on c.MenuModuleId equals mm.Id
                        join l in context.Languages on c.LanguageId equals l.Id
                        join st in context.StatusTypes on c.StatusTypeId equals st.Id

                        select new
                        {
                            c.Id,
                            Tenant = t.Name,
                            MenuModule = mm.Name,
                            Language = l.Name,
                            Status = st.Name,
                            c.Code,
                            c.Name,
                            c.StartDate,
                            c.EndDate,
                            c.TotalMonth
                        }).AsNoTracking().AsQueryable();

            if (skip == 0 || take == 0)
            {
                result.Count = await shared.GetCounts<Calendar>();
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
                result.Count = await shared.GetCounts<Calendar>();
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
            var data = (from ca in context.CalendarHistory
                        join c in context.Calendars on ca.CalendarId equals c.Id
                        join t in context.Tenants on ca.TenantId equals t.Id
                        join mm in context.MenuModules on ca.MenuModuleId equals mm.Id
                        join l in context.Languages on ca.LanguageId equals l.Id
                        join at in context.ActionTypes on ca.ActionTypeId equals at.Id
                        join et in context.ExportTypes on ca.ExportTypeId equals et.Id
                        select new
                        {
                            ca.Id,
                            Currency = c.Name,
                            Tenant = t.Name,
                            MenuModule = mm.Name,
                            Language = l.Name,
                            Action = at.Name,
                            ExportType = et.Name,
                            ca.ExportTo,
                            ca.SourceURL,
                            ca.Code,
                            ca.Name,
                            ca.StartDate,
                            ca.EndDate,
                            ca.TotalMonth,
                            ca.Browser,
                            ca.Location,
                            ca.DeviceIP,
                            ca.LocationURL,
                            ca.DeviceName,
                            ca.Latitude,
                            ca.Longitude,
                            ca.ActionBy,
                            ca.ActionAt
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
        var result = await shared.GetSingle<Calendar>(id);
        return result;
    }

    public async Task<dynamic> SoftDelete(int id)
    {
        var result = await shared.SoftDelete<Calendar>(id);
        return result;
    }

    public async Task<RequestResponse> Update(CalendarPUT masterPUT)
    {
        try
        {
            await using var transaction = await context.Database.BeginTransactionAsync();
            var isExists = await context.Calendars.AsNoTracking().AnyAsync(x => x.Name == masterPUT.Name && x.Id != masterPUT.Id);

            if (isExists == false)
            {
                await context.Calendars.Where(x => x.Id == masterPUT.Id).ExecuteUpdateAsync(x => x
                .SetProperty(x => x.TenantId, masterPUT.TenantId)
                .SetProperty(x => x.MenuModuleId, masterPUT.MenuModuleId)
                .SetProperty(x => x.LanguageId, masterPUT.LanguageId)
                .SetProperty(x => x.StatusTypeId, masterPUT.StatusTypeId)
                .SetProperty(x => x.Code, masterPUT.Code)
                .SetProperty(x => x.Name, masterPUT.Name)
                .SetProperty(x => x.StartDate, masterPUT.StartDate)
                .SetProperty(x => x.EndDate, masterPUT.EndDate)
                .SetProperty(x => x.TotalMonth, masterPUT.TotalMonth));

                CalendarHistory history = new();
                history.CalendarId = masterPUT.Id;
                history.TenantId = masterPUT.TenantId;
                history.MenuModuleId = masterPUT.MenuModuleId;
                history.LanguageId = masterPUT.LanguageId;
                history.ActionTypeId = masterPUT.ActionTypeId;
                history.ExportTypeId = masterPUT.ExportTypeId;
                history.ExportTo = masterPUT.ExportTo;
                history.SourceURL = masterPUT.SourceURL;
                history.Code = masterPUT.Code;
                history.Name = masterPUT.Name;
                history.StartDate = masterPUT.StartDate;
                history.EndDate = masterPUT.EndDate;
                history.TotalMonth = masterPUT.TotalMonth;
                history.Browser = masterPUT.Browser;
                history.Location = masterPUT.Location;
                history.DeviceIP = masterPUT.DeviceIP;
                history.LocationURL = masterPUT.LocationURL;
                history.DeviceName = masterPUT.DeviceName;
                history.Latitude = masterPUT.Latitude;
                history.Longitude = masterPUT.Longitude;
                history.ActionBy = masterPUT.ActionBy;
                history.ActionAt = DateTime.Now;

                await context.CalendarHistory.AddAsync(history);
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
