using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.CalendarModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.CalendarFeatures.SoftDeleteCommand;

public class SoftDeleteCalendarCommandHandler(IRepository repository)
{
    SoftDeleteCalendarCommandResponseModel _response;

    public async Task<SoftDeleteCalendarCommandResponseModel> Handle(SoftDeleteCalendarCommandRequestModel request)
    {
        try
        {
            var result = await repository.SoftDelete<Calendar>(request.id);

            _response = new()
            {
                StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
                IsSuccess = true,
                Message = ResponseMessage.UpdateSuccess,
                Data = result
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
