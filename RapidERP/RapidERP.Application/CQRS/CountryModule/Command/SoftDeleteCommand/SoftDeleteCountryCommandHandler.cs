using RapidERP.Application.Interfaces;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.CountryModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.CQRS.CountryModule.Command.SoftDeleteCommand;

//public class SoftDeleteCountryCommandHandler(IRepository repository)
public class SoftDeleteCountryCommandHandler(ICountryBService service)
{
    //RequestResponse requestResponse;

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
        var result = await service.SoftDelete(command.id);
        return result;
    }
}
