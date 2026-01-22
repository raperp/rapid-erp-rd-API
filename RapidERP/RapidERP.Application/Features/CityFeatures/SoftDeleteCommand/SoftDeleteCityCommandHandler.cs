using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.CityModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.CityFeatures.SoftDeleteCommand;

public class SoftDeleteCityCommandHandler(IRepository repository)
{
    SoftDeleteCityCommandResponseModel _response;

    public async Task<SoftDeleteCityCommandResponseModel> Handle(SoftDeleteCityCommandRequestModel request)
    {
        try
        {
            var result = await repository.SoftDelete<City>(request.id);

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
