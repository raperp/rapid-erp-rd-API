using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.SolutionModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.SolutionFeatures.GetAllTemplateDataQuery;

public class GetAllSolutionTemplateDataHandler(IRepository repository)
{
    GetAllSolutionTemplateDataResponseModel _response;

    public async Task<GetAllSolutionTemplateDataResponseModel> Handle(GetAllSolutionTemplateDataRequestModel query)
    {
        try
        {
            var data = await repository.GetAll<SolutionTemplate>();

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
