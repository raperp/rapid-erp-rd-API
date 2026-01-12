using RapidERP.Application.Features.ActionTypeFeatures.SoftDeleteCommand;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.ActionTypeModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.ActionTypeFeatures.SoftDeleteCommand;

public class SoftDeleteActionTypeCommandHandler(IRepository repository)
{
    SoftDeleteActionTypeCommandResponseModel _response;

    public async Task<SoftDeleteActionTypeCommandResponseModel> Handle(SoftDeleteActionTypeCommandRequestModel request)
    {
        try
        {
            var result = await repository.SoftDelete<ActionType>(request.id);

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
