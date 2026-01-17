using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.DesignationModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.DesignationFeatures.GetAllTemplateDataQuery;

public class GetAllDesignationTemplateDataHandler(IRepository repository)
{
    GetAllDesignationTemplateDataResponseModel _response;

    public async Task<GetAllDesignationTemplateDataResponseModel> Handle(GetAllDesignationTemplateDataRequestModel query)
    {
        try
        {
            var data = await repository.GetAll<DesignationTemplate>();

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
