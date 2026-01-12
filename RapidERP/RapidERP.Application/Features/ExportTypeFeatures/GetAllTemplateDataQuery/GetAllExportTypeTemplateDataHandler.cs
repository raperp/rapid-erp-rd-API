using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.ExportTypeModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.ExportTypeFeatures.GetAllTemplateDataQuery;

public class GetAllExportTypeTemplateDataHandler(IRepository repository)
{
    GetAllExportTypeTemplateDataResponseModel _response;

    public async Task<GetAllExportTypeTemplateDataResponseModel> Handle(GetAllExportTypeTemplateDataRequestModel query)
    {
        try
        {
            var data = await repository.GetAll<ExportTypeTemplate>();

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
