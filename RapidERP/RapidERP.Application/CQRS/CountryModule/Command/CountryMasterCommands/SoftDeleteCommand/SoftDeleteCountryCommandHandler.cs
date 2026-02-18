using RapidERP.Application.Interfaces.Country;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.CountryModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.CQRS.CountryModule.Command.CountryMasterCommands.SoftDeleteCommand;

//public class SoftDeleteCountryCommandHandler(IRepository repository)
public class SoftDeleteCountryCommandHandler(ICountry service)
{
    RequestResponse requestResponse;

    public async Task<RequestResponse> Handle(SoftDeleteCountryCommand command)
    {
        //try
        //{
        //    var result = await repository.SoftDelete<Country>(request.id);

        //    requestResponse = new()
        //    {
        //        StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
        //        IsSuccess = true,
        //        Message = ResponseMessage.UpdateSuccess,
        //        Data = result
        //    };

        //    return requestResponse;
        //}

        //catch (Exception ex)
        //{
        //    requestResponse = new()
        //    {
        //        StatusCode = $"{HTTPStatusCode.InternalServerError} {HTTPStatusCode.StatusCode500}",
        //        IsSuccess = false,
        //        Message = ex.Message
        //    };

        //    return requestResponse;
        //}
        //var result = await service.UpdateStatus(command.id);
        return requestResponse;
    }
}
