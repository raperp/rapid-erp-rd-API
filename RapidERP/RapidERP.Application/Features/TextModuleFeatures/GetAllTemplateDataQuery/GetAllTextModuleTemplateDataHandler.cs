using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.TextModuleModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.TextModuleFeatures.GetAllTemplateDataQuery;

public class GetAllTextModuleTemplateDataHandler(IRepository repository)
{
    GetAllTextModuleTemplateDataResponseModel _response;

    public async Task<GetAllTextModuleTemplateDataResponseModel> Handle(GetAllTextModuleTemplateDataRequestModel query)
    {
        try
        {
            var data = await repository.GetAll<TextModuleTemplate>();

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
