using Microsoft.EntityFrameworkCore;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.ExportTypeModels;
using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.ExportTypeFeatures.GetHistoryQuery;

public class GetHistoryExportTypeHandler(IRepository repository)
{
    GetHistoryExportTypeResponseModel _response;

    public async Task<GetHistoryExportTypeResponseModel> Handle(GetHistoryExportTypeRequestModel query)
    {
        try
        {
            var data = (from eta in repository.Set<ExportTypeHistory>()
                        join et in repository.Set<ExportType>() on eta.ExportTypeId equals et.Id
                        join l in repository.Set<Language>() on eta.LanguageId equals l.Id
                        select new GetHistoryExportTypeResponseDTOModel
                        {
                            Id = eta.Id,
                            ExportType = et.Name,
                            Language = l.Name,
                            Name = eta.Name,
                            Description = eta.Description,
                            Browser = eta.Browser,
                            Location = eta.Location,
                            DeviceIP = eta.DeviceIP,
                            LocationURL = eta.LocationURL,
                            DeviceName = eta.DeviceName,
                            Latitude = eta.Latitude,
                            Longitude = eta.Longitude,
                            ActionBy = eta.ActionBy,
                            ActionAt = eta.ActionAt
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
