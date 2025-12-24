using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.CountryModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.CountryFeatures.SoftDeleteCommand;

public class SoftDeleteCountryCommandHandler(IRepository repository)
{
    SoftDeleteCountryCommandResponseModel _response;

    public async Task<SoftDeleteCountryCommandResponseModel> Handle(SoftDeleteCountryCommandRequestModel request)
    {
       try
       {
            var result = await repository.SoftDelete<Country>(request.id);

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
