using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.TenantModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.TenantFeatures.SoftDeleteCommand;

public class SoftDeleteTenantCommandHandler(IRepository repository)
{
    SoftDeleteTenantCommandResponseModel _response;

    public async Task<SoftDeleteTenantCommandResponseModel> Handle(SoftDeleteTenantCommandRequestModel request)
    {
        try
        {
            //var result = await repository.UpdateStatus<Tenant>(request.id);

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
