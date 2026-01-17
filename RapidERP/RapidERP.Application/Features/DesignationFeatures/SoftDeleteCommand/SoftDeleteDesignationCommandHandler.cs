using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.DesignationModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.DesignationFeatures.SoftDeleteCommand;

public class SoftDeleteDesignationCommandHandler(IRepository repository)
{
    SoftDeleteDesignationCommandResponseModel _response;

    public async Task<SoftDeleteDesignationCommandResponseModel> Handle(SoftDeleteDesignationCommandRequestModel request)
    {
        try
        {
            var result = await repository.SoftDelete<Designation>(request.id);

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
