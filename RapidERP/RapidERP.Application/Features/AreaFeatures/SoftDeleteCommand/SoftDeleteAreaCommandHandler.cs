using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.AreaModules;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.AreaFeatures.SoftDeleteCommand;

public class SoftDeleteAreaCommandHandler(IRepository repository)
{
    SoftDeleteAreaCommandResponseModel _response;

    public async Task<SoftDeleteAreaCommandResponseModel> Handle(SoftDeleteAreaCommandRequestModel request)
    {
        try
        {
            //var result = await repository.UpdateStatus<Area>(request.id);

            _response = new()
            {
                StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
                IsSuccess = true,
                Message = ResponseMessage.UpdateSuccess,
                //Data = result
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
