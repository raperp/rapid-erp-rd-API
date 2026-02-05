using Microsoft.EntityFrameworkCore;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.ActionTypeModels;
using RapidERP.Domain.Entities.AreaModules;
using RapidERP.Domain.Entities.CityModels;
using RapidERP.Domain.Entities.CountryModels;
using RapidERP.Domain.Entities.ExportTypeModels;
using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Entities.MenuModuleModels;
using RapidERP.Domain.Entities.SateModules;
using RapidERP.Domain.Entities.TenantModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.AreaFeatures.GetHistoryQuery;   

public class GetHistoryAreaHandler(IRepository repository)
{
    GetHistoryAreaResponseModel _response;

    public async Task<GetHistoryAreaResponseModel> Handle(GetHistoryAreaRequestModel query)
    {
        try
        {
            var data = (from aa in repository.Set<AreaHistory>()
                        join a in repository.Set<Area>() on aa.AreaId equals a.Id
                        join c in repository.Set<Country>() on aa.AreaId equals c.Id
                        join sta in repository.Set<State>() on aa.StateId equals sta.Id
                        join cit in repository.Set<City>() on aa.CityId equals cit.Id
                        join mm in repository.Set<MenuModule>() on aa.MenuModuleId equals mm.Id
                        join t in repository.Set<Tenant>() on aa.TenantId equals t.Id
                        //join l in repository.Set<Language>() on aa.LanguageId equals l.Id
                        join at in repository.Set<ActionType>() on aa.ActionTypeId equals at.Id
                        join et in repository.Set<ExportType>() on aa.ExportTypeId equals et.Id
                        select new GetHistoryAreaResponseDTOModel
                        {
                            Id = aa.Id,
                            Name = aa.Name,
                            Code = aa.Code,
                            Country = c.Name,
                            State = sta.Name,
                            City = cit.Name,
                            Tanent = t.Name,
                            //Language = l.Name,
                            MenuModule = mm.Name,
                            ActionType = at.Name,
                            ExportType = et.Name,
                            ExportTo = aa.ExportTo,
                            SourceURL = aa.SourceURL,
                            //Browser = aa.Browser,
                            //Location = aa.Location,
                            //DeviceIP = aa.DeviceIP,
                            //LocationURL = aa.LocationURL,
                            //DeviceName = aa.DeviceName,
                            //Latitude = aa.Latitude,
                            //Longitude = aa.Longitude,
                            //ActionBy = aa.ActionBy,
                            //ActionAt = aa.ActionAt
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
