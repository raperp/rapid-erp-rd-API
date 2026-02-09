using Microsoft.EntityFrameworkCore;
using RapidERP.Application.Interfaces;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.CountryModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.CQRS.CountryModule.Command.CountryMasterCommands.DeleteCommand;

//public class DeleteCountryCommandHandler(IRepository repository)
public class DeleteCountryCommandHandler(ICountryService service)
{
    //RequestResponse requestResponse;

    public async Task<RequestResponse> Handle(DeleteCountryCommand command)
    {
        //try
        //{
        //    if (request.id is not 0)
        //    {
        //        var histories = await repository.Set<CountryAudit>().Where(c => c.CountryId == request.id).Select(x => x.Id).ToListAsync();

        //        foreach (var item in histories)
        //        {
        //            await repository.Delete<CountryAudit>(item);
        //        }


        //        await repository.Delete<Country>(request.id);

        //        requestResponse = new()
        //        {
        //            StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
        //            IsSuccess = true,
        //            Message = ResponseMessage.DeleteSuccess
        //        };
        //    }

        //    else
        //    {
        //        requestResponse = new()
        //        {
        //            StatusCode = $"{HTTPStatusCode.NotFound} {HTTPStatusCode.StatusCode404}",
        //            IsSuccess = false,
        //            Message = ResponseMessage.NoRecordFound
        //        };
        //    }
        //}

        //catch (Exception ex)
        //{
        //    requestResponse = new()
        //    {
        //        StatusCode = $"{HTTPStatusCode.InternalServerError} {HTTPStatusCode.StatusCode500}",
        //        IsSuccess = false,
        //        Message = ex.Message
        //    };
        //}

        //return requestResponse;

        var result = await service.Delete(command.id);
        return result;
    }
}
