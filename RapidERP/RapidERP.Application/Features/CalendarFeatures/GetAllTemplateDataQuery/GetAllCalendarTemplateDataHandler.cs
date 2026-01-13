using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.CalendarModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.CalendarFeatures.GetAllTemplateDataQuery;

public class GetAllCalendarTemplateDataHandler(IRepository repository)
{
    GetAllCalendarTemplateDataResponseModel _response;

    public async Task<GetAllCalendarTemplateDataResponseModel> Handle(GetAllCalendarTemplateDataRequestModel query)
    {
        try
        {
            var data = await repository.GetAll<CalendarTemplate>();

            _response = new()
            {
                StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
                IsSuccess = true,
                Message = ResponseMessage.FetchSuccess,
                Data = data
            };

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
