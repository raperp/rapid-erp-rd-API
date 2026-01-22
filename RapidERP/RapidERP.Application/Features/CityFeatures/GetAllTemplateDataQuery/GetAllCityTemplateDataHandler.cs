using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.CityModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.CityFeatures.GetAllTemplateDataQuery;

public class GetAllCityTemplateDataHandler(IRepository repository)
{
    GetAllCityTemplateDataResponseModel _response;

    public async Task<GetAllCityTemplateDataResponseModel> Handle(GetAllCityTemplateDataRequestModel query)
    {
        try
        {
            var data = await repository.GetAll<CityTemplate>();

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
