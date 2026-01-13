using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.MenuModuleModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.MenuModuleFeatures.SoftDeleteCommand;

public class SoftDeleteMenuModuleCommandHandler(IRepository repository)
{
    SoftDeleteMenuModuleCommandResponseModel _response;

    public async Task<SoftDeleteMenuModuleCommandResponseModel> Handle(SoftDeleteMenuModuleCommandRequestModel request)
    {
        try
        {
            var result = await repository.SoftDelete<MenuModule>(request.id);

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
                StatusCode = $"{HTTPStatusCode.BadRequest} {HTTPStatusCode.StatusCode400}",
                IsSuccess = false,
                Message = ex.Message
            };

            return _response;
        }
    }
}
