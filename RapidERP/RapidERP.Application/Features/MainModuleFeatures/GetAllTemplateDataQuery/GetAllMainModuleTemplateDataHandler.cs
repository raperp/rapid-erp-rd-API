using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.MainModuleModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.MainModuleFeatures.GetAllTemplateDataQuery;

public class GetAllMainModuleTemplateDataHandler(IRepository repository)
{
    GetAllMainModuleTemplateDataResponseModel _response;

    public async Task<GetAllMainModuleTemplateDataResponseModel> Handle(GetAllMainModuleTemplateDataRequestModel query)
    {
        try
        {
            var data = await repository.GetAll<MainModuleTemplate>();

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
