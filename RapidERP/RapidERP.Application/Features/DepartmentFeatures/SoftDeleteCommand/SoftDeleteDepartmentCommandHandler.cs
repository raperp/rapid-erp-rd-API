using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.DepartmentModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.DepartmentFeatures.SoftDeleteCommand;

public class SoftDeleteDepartmentCommandHandler(IRepository repository)
{
    SoftDeleteDepartmentCommandResponseModel _response;

    public async Task<SoftDeleteDepartmentCommandResponseModel> Handle(SoftDeleteDepartmentCommandRequestModel request)
    {
        try
        {
            var result = await repository.SoftDelete<Department>(request.id);

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
