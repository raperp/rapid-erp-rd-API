using Microsoft.EntityFrameworkCore;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.ActionTypeModels;
using RapidERP.Domain.Entities.ExportTypeModels;
using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Entities.MessageModuleModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.MessageModuleFeatures.GetHistoryQuery;

public class GetHistoryMessageModuleHandler(IRepository repository)
{
    GetHistoryMessageModuleResponseModel _response;

    public async Task<GetHistoryMessageModuleResponseModel> Handle(GetHistoryMessageModuleRequestModel query)
    {
        try
        {
            var data = (from mma in repository.Set<MessageModuleHistory>()
                        join mm in repository.Set<MessageModule>() on mma.MessageModuleId equals mm.Id
                        join at in repository.Set<ActionType>() on mma.ActionTypeId equals at.Id
                        //join l in repository.Set<Language>() on mma.LanguageId equals l.Id
                        join et in repository.Set<ExportType>() on mma.ExportTypeId equals et.Id
                        select new GetHistoryMessageModuleResponseDTOModel
                        {
                            Id = mma.Id,
                            TextModule = mm.Name,
                            //Language = l.Name,
                            Action = at.Name,
                            ExportType = et.Name,
                            ExportTo = mma.ExportTo,
                            SourceURL = mma.SourceURL,
                            Name = mma.Name,
                            //Browser = mma.Browser,
                            //Location = mma.Location,
                            //DeviceIP = mma.DeviceIP,
                            //LocationURL = mma.LocationURL,
                            //DeviceName = mma.DeviceName,
                            //Latitude = mma.Latitude,
                            //Longitude = mma.Longitude,
                            //ActionBy = mma.ActionBy,
                            //ActionAt = mma.ActionAt
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
