using RapidERP.Application.Interfaces;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.CQRS.CountryModule.Query.CountryMasterQueries.GetAllQuery;

//public class GetAllCountryHandler(IRepository repository)
public class GetAllCountryHandler(ICountryService service)
{
    //RequestResponse requestResponse;

    public async Task<RequestResponse> Handle(GetAllCountryCommand query)
    {
        //try
        //{
        //    GetAllDTO result = new();

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
        //                    c.Name,
        //                    c.IsDefault,
        //                    c.IsDraft,
        //                    c.ISONumeric,
        //                    c.ISO2Code,
        //                    c.ISO3Code,
        //                    c.FlagURL
        //                }).AsNoTracking().AsQueryable();

        //    if (query.skip == 0 || query.take == 0)
        //    {
        //        //result.Count = await repository.GetCounts<Country>(query.pageSize);
        //        result.Data = await data.ToListAsync();

        //        requestResponse = new()
        //        {
        //            StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
        //            IsSuccess = true,
        //            Message = ResponseMessage.FetchSuccess,
        //            Data = result.Data
        //        };
        //    }

        //    else
        //    {
        //        //result.Count = await repository.GetCounts<Country>(query.pageSize);
        //        result.Data = await data.Skip(query.skip).Take(query.take).ToListAsync();

        //        requestResponse = new()
        //        {
        //            StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
        //            IsSuccess = true,
        //            Message = ResponseMessage.FetchSuccessWithPagination,
        //            Data = result.Data
        //        };
        //    }

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
        var result = await service.GetAll(query.skip, query.take);
        return result;
    }
}
