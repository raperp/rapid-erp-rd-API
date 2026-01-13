using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.SubmoduleModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.SubModuleFeatures.SoftDeleteCommand;

public class SoftDeleteSubModuleCommandHandler(IRepository repository)
{
    SoftDeleteSubModuleCommandResponseModel _response;

    public async Task<SoftDeleteSubModuleCommandResponseModel> Handle(SoftDeleteSubModuleCommandRequestModel request)
    {
        try
        {
            var result = await repository.SoftDelete<Submodule>(request.id);

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
