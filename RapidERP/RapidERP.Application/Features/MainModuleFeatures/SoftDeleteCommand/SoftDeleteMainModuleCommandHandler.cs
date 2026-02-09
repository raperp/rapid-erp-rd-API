using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.MainModuleModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.MainModuleFeatures.SoftDeleteCommand;

public class SoftDeleteMainModuleCommandHandler(IRepository repository)
{
    SoftDeleteMainModuleCommandResponseModel _response;

    public async Task<SoftDeleteMainModuleCommandResponseModel> Handle(SoftDeleteMainModuleCommandRequestModel request)
    {
        try
        {
            //var result = await repository.UpdateStatus<MainModule>(request.id);

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
