using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.MessageModuleModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.MessageModuleFeatures.SoftDeleteCommand;

public class SoftDeleteMessageModuleCommandHandler(IRepository repository)
{
    SoftDeleteMessageModuleCommandResponseModel _response;

    public async Task<SoftDeleteMessageModuleCommandResponseModel> Handle(SoftDeleteMessageModuleCommandRequestModel request)
    {
        try
        {
            //var result = await repository.UpdateStatus<MessageModule>(request.id);

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
