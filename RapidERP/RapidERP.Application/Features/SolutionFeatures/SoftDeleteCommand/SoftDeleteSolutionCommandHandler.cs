using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.SolutionModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.SolutionFeatures.SoftDeleteCommand;

public class SoftDeleteSolutionCommandHandler(IRepository repository)
{
    SoftDeleteSolutionCommandResponseModel _response;

    public async Task<SoftDeleteSolutionCommandResponseModel> Handle(SoftDeleteSolutionCommandRequestModel request)
    {
        try
        {
            //var result = await repository.UpdateStatus<Solution>(request.id);

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
