using Microsoft.EntityFrameworkCore;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.ActionTypeModels;
using RapidERP.Domain.Entities.ExportTypeModels;
using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.ActionTypeFeatures.GetHistoryQuery;

public class GetHistoryActionTypeHandler(IRepository repository)
{
    GetHistoryActionTypeResponseModel _response;

    public async Task<GetHistoryActionTypeResponseModel> Handle(GetHistoryActionTypeRequestModel query)
    {
        try
        {
            var data = (from ath in repository.Set<ActionTypeHistory>()
                        join at in repository.Set<ActionType>() on ath.ActionTypeId equals at.Id
                        join l in repository.Set<Language>() on ath.LanguageId equals l.Id
                        join et in repository.Set<ExportType>() on ath.ExportTypeId equals et.Id
                        select new GetHistoryActionTypeResponseDTOModel
                        {
                            Id = ath.Id,
                            ActionType = at.Name,
                            Language = l.Name,
                            ExportType = et.Name,
                            ExportTo = ath.ExportTo,
                            SourceURL = ath.SourceURL,
                            Name = ath.Name,
                            Description = ath.Description,
                            Browser = ath.Browser,
                            Location = ath.Location,
                            DeviceIP = ath.DeviceIP,
                            LocationURL = ath.LocationURL,
                            DeviceName = ath.DeviceName,
                            Latitude = ath.Latitude,
                            Longitude = ath.Longitude,
                            ActionBy = ath.ActionBy,
                            ActionAt = ath.ActionAt
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
