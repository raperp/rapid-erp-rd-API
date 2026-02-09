using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.CurrencyModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.CurrencyFeatures.SoftDeleteCommand;

public class SoftDeleteCurrencyCommandHandler(IRepository repository)
{
    SoftDeleteCurrencyCommandResponseModel _response;

    public async Task<SoftDeleteCurrencyCommandResponseModel> Handle(SoftDeleteCurrencyCommandRequestModel request)
    {
        try
        {
            //var result = await repository.UpdateStatus<Currency>(request.id);

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
