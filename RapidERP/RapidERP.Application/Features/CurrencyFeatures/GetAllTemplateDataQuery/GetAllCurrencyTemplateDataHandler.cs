using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.CurrencyModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.CurrencyFeatures.GetAllTemplateDataQuery;

public class GetAllCurrencyTemplateDataHandler(IRepository repository)
{
    GetAllCurrencyTemplateDataResponseModel _response;

    public async Task<GetAllCurrencyTemplateDataResponseModel> Handle(GetAllCurrencyTemplateDataRequestModel query)
    {
        try
        {
            var data = await repository.GetAll<CurrencyTemplate>();

            _response = new()
            {
                StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
                IsSuccess = true,
                Message = ResponseMessage.FetchSuccess,
                Data = data
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
