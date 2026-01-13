using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.SubmoduleModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.SubModuleFeatures.GetAllTemplateDataQuery;

public class GetAllSubModuleTemplateDataHandler(IRepository repository)
{
    GetAllSubModuleTemplateDataResponseModel _response;

    public async Task<GetAllSubModuleTemplateDataResponseModel> Handle(GetAllSubModuleTemplateDataRequestModel query)
    {
        try
        {
            var data = await repository.GetAll<SubmoduleTemplate>();

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
