using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.CountryModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.CountryFeatures.GetAllCountryTemplateDataQuery;

public class GetAllCountryTemplateDataHandler(IRepository repository)
{
    GetAllCountryTemplateDataResponseModel _response;

    public async Task<GetAllCountryTemplateDataResponseModel> Handle(GetAllCountryTemplateDataRequestModel query)
    {
        try
        {
            var data = await repository.GetAll<CountryTemplate>();

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
