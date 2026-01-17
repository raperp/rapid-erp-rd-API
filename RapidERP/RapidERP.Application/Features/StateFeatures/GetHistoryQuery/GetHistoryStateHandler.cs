using Microsoft.EntityFrameworkCore;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.ActionTypeModels;
using RapidERP.Domain.Entities.CountryModels;
using RapidERP.Domain.Entities.ExportTypeModels;
using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Entities.MenuModuleModels;
using RapidERP.Domain.Entities.SateModules;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.StateFeatures.GetHistoryQuery;

public class GetHistoryStateHandler(IRepository repository)
{
    GetHistoryStateResponseModel _response;

    public async Task<GetHistoryStateResponseModel> Handle(GetHistoryStateRequestModel query)
    {
        try
        {
            var data = (from sa in repository.Set<StateHistory>()
                        join s in repository.Set<State>() on sa.StateId equals s.Id
                        join mm in repository.Set<MenuModule>() on sa.MenuModuleId equals mm.Id
                        join c in repository.Set<Country>() on sa.CountryId equals c.Id
                        join at in repository.Set<ActionType>() on sa.ActionTypeId equals at.Id
                        join l in repository.Set<Language>() on sa.LanguageId equals l.Id
                        join et in repository.Set<ExportType>() on sa.ExportTypeId equals et.Id
                        select new GetHistoryStateResponseDTOModel
                        {
                            Id = sa.Id,
                            State = s.Name,
                            MenuModule = mm.Name,
                            Country = c.Name,
                            Language = l.Name,
                            Action = at.Name,
                            ExportType = et.Name,
                            ExportTo = sa.ExportTo,
                            SourceURL = sa.SourceURL,
                            Code = sa.Code,
                            Name = sa.Name,
                            IsDefault = sa.IsDefault,
                            IsDraft = sa.IsDraft,
                            Browser = sa.Browser,
                            Location = sa.Location,
                            DeviceIP = sa.DeviceIP,
                            LocationURL = sa.LocationURL,
                            DeviceName = sa.DeviceName,
                            Latitude = sa.Latitude,
                            Longitude = sa.Longitude,
                            ActionBy = sa.ActionBy,
                            ActionAt = sa.ActionAt
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
