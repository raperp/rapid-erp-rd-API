using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.SateModules;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.StateFeatures.SoftDeleteCommand;

public class SoftDeleteStateCommandHandler(IRepository repository)
{
    SoftDeleteStateCommandResponseModel _response;

    public async Task<SoftDeleteStateCommandResponseModel> Handle(SoftDeleteStateCommandRequestModel request)
    {
        try
        {
            var result = await repository.SoftDelete<State>(request.id);

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
