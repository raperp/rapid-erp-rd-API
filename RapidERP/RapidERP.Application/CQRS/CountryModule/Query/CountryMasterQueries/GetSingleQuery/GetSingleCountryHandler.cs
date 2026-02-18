using Microsoft.EntityFrameworkCore;
using RapidERP.Application.Interfaces.Country;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.CountryModels;
using RapidERP.Domain.Entities.CurrencyModels;
using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Entities.MenuModuleModels;
using RapidERP.Domain.Entities.StatusTypeModels;
using RapidERP.Domain.Entities.TenantModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.CQRS.CountryModule.Query.CountryMasterQueries.GetSingleQuery;

//public class GetSingleCountryHandler(IRepository repository)
public class GetSingleCountryHandler(ICountry service)
{
    //RequestResponse requestResponse;

    public async Task<RequestResponse> Handle(GetSingleCountryCommand request)
    {
        //try
        //{
        //    var data = (from c in repository.Set<Country>()
        //                join st in repository.Set<StatusType>() on c.StatusTypeId equals st.Id
        //                join t in repository.Set<Tenant>() on c.TenantId equals t.Id
        //                join l in repository.Set<Language>() on c.LanguageId equals l.Id
        //                join mm in repository.Set<MenuModule>() on c.MenuModuleId equals mm.Id
        //                join cu in repository.Set<Currency>() on c.CurrencyId equals cu.Id
        //                select new
        //                {
        //                    c.Id,
        //                    MenuModule = mm.Name,
        //                    Tanent = t.Name,
        //                    Language = l.Name,
        //                    Status = st.Name,
        //                    Currency = cu.Name,
        //                    c.DialCode,
        //                    Country = c.Name,
        //                    c.IsDefault,
        //                    c.IsDraft,
        //                    c.ISONumeric,
        //                    c.ISO2Code,
        //                    c.ISO3Code,
        //                    c.FlagURL
        //                }).AsNoTracking().AsQueryable();

        //    var result = data.Where(x => x.Id == request.id).ToListAsync();

        //    requestResponse = new()
        //    {
        //        StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
        //        IsSuccess = true,
        //        Message = ResponseMessage.FetchSuccess,
        //        Data = result.Result.FirstOrDefault()
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
        var result = await service.GetById(request.id);
        return result;
    }
}
