using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.SateModules;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.StateFeatures.GetAllTemplateDataQuery;

public class GetAllStateTemplateDataHandler(IRepository repository)
{
    GetAllStateTemplateDataResponseModel _response;

    public async Task<GetAllStateTemplateDataResponseModel> Handle(GetAllStateTemplateDataRequestModel query)
    {
        try
        {
            var data = await repository.GetAll<StateTemplate>();

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
