using Microsoft.EntityFrameworkCore;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.ActionTypeModels;
using RapidERP.Domain.Entities.CalendarModels;
using RapidERP.Domain.Entities.ExportTypeModels;
using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Entities.MenuModuleModels;
using RapidERP.Domain.Entities.TenantModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.CalendarFeatures.GetHistoryQuery;

public class GetHistoryCalendarHandler(IRepository repository)
{
    GetHistoryCalendarResponseModel _response;

    public async Task<GetHistoryCalendarResponseModel> Handle(GetHistoryCalendarRequestModel query)
    {
        try
        {
            var data = (from ca in repository.Set<CalendarHistory>()
                        join c in repository.Set<Calendar>() on ca.CalendarId equals c.Id
                        join t in repository.Set<Tenant>() on ca.TenantId equals t.Id
                        join mm in repository.Set<MenuModule>() on ca.MenuModuleId equals mm.Id
                        join l in repository.Set<Language>() on ca.LanguageId equals l.Id
                        join at in repository.Set<ActionType>() on ca.ActionTypeId equals at.Id
                        join et in repository.Set<ExportType>() on ca.ExportTypeId equals et.Id
                        select new GetHistoryCalendarResponseDTOModel
                        {
                            Id = ca.Id,
                            Currency = c.Name,
                            Tenant = t.Name,
                            MenuModule = mm.Name,
                            Language = l.Name,
                            Action = at.Name,
                            ExportType = et.Name,
                            ExportTo = ca.ExportTo,
                            SourceURL = ca.SourceURL,
                            Code = ca.Code,
                            Name = ca.Name,
                            StartDate = ca.StartDate,
                            EndDate = ca.EndDate,
                            TotalMonth = ca.TotalMonth,
                            Browser = ca.Browser,
                            Location = ca.Location,
                            DeviceIP = ca.DeviceIP,
                            LocationURL = ca.LocationURL,
                            DeviceName = ca.DeviceName,
                            Latitude = ca.Latitude,
                            Longitude = ca.Longitude,
                            ActionBy = ca.ActionBy,
                            ActionAt = ca.ActionAt
                        }).AsNoTracking().AsQueryable();

            if (query.skip == 0 || query.take == 0)
            {
                var result = await data.ToListAsync();

                _response = new()
                {
                    StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
                    IsSuccess = true,
                    Message = ResponseMessage.FetchSuccess,
                    Data = result
                };
            }

            else
            {
                var result = await data.Skip(query.skip).Take(query.take).ToListAsync();

                _response = new()
                {
                    StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
                    IsSuccess = true,
                    Message = ResponseMessage.FetchSuccessWithPagination,
                    Data = result
                };
            }

            return _response;
        }

        catch (Exception ex)
        {
            _response = new()
            {
                StatusCode = $"{HTTPStatusCode.InternalServerError} {HTTPStatusCode.StatusCode500}",
                IsSuccess = false,
                Message = ex.Message
            };

            return _response;
        }
    }
}
