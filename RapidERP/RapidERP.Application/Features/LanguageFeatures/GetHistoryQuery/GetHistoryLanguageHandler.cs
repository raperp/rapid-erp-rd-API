using Microsoft.EntityFrameworkCore;
using RapidERP.Application.Features.CountryFeatures.GetHistoryQuery;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.LanguageFeatures.GetHistoryQuery;

public class GetHistoryLanguageHandler(IRepository repository)
{
    GetHistoryLanguageResponseModel _response;

    public async Task<GetHistoryLanguageResponseModel> Handle(GetHistoryCountryRequestModel query)
    {
        try
        {
            var data = (from la in repository.Set<LanguageHistory>()
                        join l in repository.Set<Language>() on la.LanguageId equals l.Id
                        select new GetHistoryLanguageResponseDTOModel
                        {
                            Id = la.Id,
                            Language = l.Name,
                            ISONumeric = la.ISONumeric,
                            Name = la.Name,
                            ISO2Code = la.ISO2Code,
                            ISO3Code = la.ISO3Code,
                            IconURL = la.IconURL,
                            Browser = la.Browser,
                            Location = la.Location,
                            DeviceIP = la.DeviceIP,
                            LocationURL = la.LocationURL,
                            DeviceName = la.DeviceName,
                            Latitude = la.Latitude,
                            Longitude = la.Longitude,
                            ActionBy = la.ActionBy,
                            ActionAt = la.ActionAt
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
