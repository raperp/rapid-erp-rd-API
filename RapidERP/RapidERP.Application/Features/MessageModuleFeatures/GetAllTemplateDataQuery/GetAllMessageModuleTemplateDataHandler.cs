using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.MessageModuleModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.MessageModuleFeatures.GetAllTemplateDataQuery;

public class GetAllMessageModuleTemplateDataHandler(IRepository repository)
{
    GetAllMessageModuleTemplateDataResponseModel _response;

    public async Task<GetAllMessageModuleTemplateDataResponseModel> Handle(GetAllMessageModuleTemplateDataRequestModel query)
    {
        try
        {
            var data = await repository.GetAll<MessageModuleTemplate>();

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
