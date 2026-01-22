using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.KitchenModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.KitchenFeatures.GetAllTemplateDataQuery;

public class GetAllKitchenTemplateDataHandler(IRepository repository)
{
    GetAllKitchenTemplateDataResponseModel _response;

    public async Task<GetAllKitchenTemplateDataResponseModel> Handle(GetAllKitchenTemplateDataRequestModel query)
    {
        try
        {
            var data = await repository.GetAll<KitchenTemplate>();

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
