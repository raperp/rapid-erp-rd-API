using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.StatusTypeModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.StatusTypeFeatures.SoftDeleteCommand;

public class SoftDeleteStatusTypeCommandHandler(IRepository repository)
{
    SoftDeleteStatusTypeCommandResponseModel _response;

    public async Task<SoftDeleteStatusTypeCommandResponseModel> Handle(SoftDeleteStatusTypeCommandRequestModel request)
    {
        try
        {
            //var result = await repository.UpdateStatus<StatusType>(request.id);

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
