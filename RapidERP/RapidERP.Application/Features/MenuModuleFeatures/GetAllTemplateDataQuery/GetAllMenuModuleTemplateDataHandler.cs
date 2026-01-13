using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.MenuModuleModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.MenuModuleFeatures.GetAllTemplateDataQuery;

public class GetAllMenuModuleTemplateDataHandler(IRepository repository)
{
    GetAllMenuModuleTemplateDataResponseModel _response;

    public async Task<GetAllMenuModuleTemplateDataResponseModel> Handle(GetAllMenuModuleTemplateDataRequestModel query)
    {
        try
        {
            var data = await repository.GetAll<MenuModuleTemplate>();

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
