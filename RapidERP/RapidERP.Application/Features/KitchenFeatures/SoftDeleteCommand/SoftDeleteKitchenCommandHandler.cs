using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.KitchenModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.KitchenFeatures.SoftDeleteCommand;

public class SoftDeleteKitchenCommandHandler(IRepository repository)
{
    SoftDeleteKitchenCommandResponseModel _response;

    public async Task<SoftDeleteKitchenCommandResponseModel> Handle(SoftDeleteKitchenCommandRequestModel request)
    {
        try
        {
            var result = await repository.SoftDelete<Kitchen>(request.id);

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
