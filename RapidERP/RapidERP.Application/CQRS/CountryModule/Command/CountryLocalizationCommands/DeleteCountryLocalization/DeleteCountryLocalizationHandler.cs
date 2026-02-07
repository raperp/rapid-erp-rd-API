using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.CountryModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.CQRS.CountryModule.Command.CountryLocalizationCommands.DeleteCountryLocalization;

public class DeleteCountryLocalizationHandler(IRepository repository)
{
    RequestResponse requestResponse;

    public async Task<RequestResponse> Handle(DeleteCountryLocalizationCommand request)
    {
        try
        {
            if (request.id is not 0)
            {
                await repository.Delete<CountryLocalization>(request.id);

                requestResponse = new()
                {
                    StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
                    IsSuccess = true,
                    Message = ResponseMessage.DeleteSuccess
                };
            }

            else
            {
                requestResponse = new()
                {
                    StatusCode = $"{HTTPStatusCode.NotFound} {HTTPStatusCode.StatusCode404}",
                    IsSuccess = false,
                    Message = ResponseMessage.NoRecordFound
                };
            }
            
            return requestResponse;
        }

        catch (Exception ex)
        {
            requestResponse = new()
            {
                StatusCode = $"{HTTPStatusCode.InternalServerError} {HTTPStatusCode.StatusCode500}",
                IsSuccess = false,
                Message = ex.Message
            };
            
            return requestResponse;
        } 
    }
}
