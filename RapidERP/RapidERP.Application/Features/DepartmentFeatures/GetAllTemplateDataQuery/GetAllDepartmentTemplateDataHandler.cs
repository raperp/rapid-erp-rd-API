using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.DepartmentModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.DepartmentFeatures.GetAllTemplateDataQuery;

public class GetAllDepartmentTemplateDataHandler(IRepository repository)
{
    GetAllDepartmentTemplateDataResponseModel _response;

    public async Task<GetAllDepartmentTemplateDataResponseModel> Handle(GetAllDepartmentTemplateDataRequestModel query)
    {
        try
        {
            var data = await repository.GetAll<DepartmentTemplate>();

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
