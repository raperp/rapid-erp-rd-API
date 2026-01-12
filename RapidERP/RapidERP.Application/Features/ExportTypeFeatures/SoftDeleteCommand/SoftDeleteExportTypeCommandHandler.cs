using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.ExportTypeModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.ExportTypeFeatures.SoftDeleteCommand;

public class SoftDeleteExportTypeCommandHandler(IRepository repository)
{
    SoftDeleteExportTypeCommandResponseModel _response;

    public async Task<SoftDeleteExportTypeCommandResponseModel> Handle(SoftDeleteExportTypeCommandRequestModel request)
    {
        try
        {
            var result = await repository.SoftDelete<ExportType>(request.id);

            _response = new()
            {
                StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
                IsSuccess = true,
                Message = ResponseMessage.UpdateSuccess,
                Data = result
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
