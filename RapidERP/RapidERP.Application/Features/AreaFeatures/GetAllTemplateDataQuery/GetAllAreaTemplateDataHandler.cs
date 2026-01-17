using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.AreaModules;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.AreaFeatures.GetAllTemplateDataQuery;

public class GetAllAreaTemplateDataHandler(IRepository repository)
{
    GetAllAreaTemplateDataResponseModel _response;

    public async Task<GetAllAreaTemplateDataResponseModel> Handle(GetAllAreaTemplateDataRequestModel query)
    {
        try
        {
            var data = await repository.GetAll<AreaTemplate>();

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
