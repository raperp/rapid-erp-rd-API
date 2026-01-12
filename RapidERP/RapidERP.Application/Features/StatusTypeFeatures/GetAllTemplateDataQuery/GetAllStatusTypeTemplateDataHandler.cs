using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.StatusTypeModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.StatusTypeFeatures.GetAllTemplateDataQuery;

public class GetAllStatusTypeTemplateDataHandler(IRepository repository)
{
    GetAllStatusTypeTemplateDataResponseModel _response;

    public async Task<GetAllStatusTypeTemplateDataResponseModel> Handle(GetAllStatusTypeTemplateDataRequestModel query)
    {
        try
        {
            var data = await repository.GetAll<StatusTypeTemplate>();

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
