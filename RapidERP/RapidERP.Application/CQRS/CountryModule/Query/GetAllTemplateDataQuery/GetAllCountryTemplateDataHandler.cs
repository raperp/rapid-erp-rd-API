using RapidERP.Application.Interfaces;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.CountryModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.CQRS.CountryModule.Query.GetAllTemplateDataQuery;

//public class GetAllCountryTemplateDataHandler(IRepository repository)
public class GetAllCountryTemplateDataHandler(ICountryBService service)
{
    //RequestResponse requestResponse;

    public async Task<RequestResponse> Handle(GetAllCountryTemplateDataCommand query)
    {
        //try
        //{
        //    var data = await repository.GetAll<CountryTemplate>();

        //    requestResponse = new()
        //    {
        //        StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
        //        IsSuccess = true,
        //        Message = ResponseMessage.FetchSuccess,
        //        Data = data
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

        var result = await service.GetTemplate();
        return result;
    }
}
