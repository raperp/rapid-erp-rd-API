using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.ActionTypeModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.ActionTypeFeatures.GetAllTemplateDataQuery;

public class GetAllActionTypeTemplateDataHandler(IRepository repository)
{
    GetAllActionTypeTemplateDataResponseModel _response;

    public async Task<GetAllActionTypeTemplateDataResponseModel> Handle(GetAllActionTypeTemplateDataRequestModel query)
    {
        try
        {
            var data = await repository.GetAll<ActionTypeTemplate>();

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
