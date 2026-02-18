using Microsoft.EntityFrameworkCore;
using RapidERP.Application.DTOs.Shared;
using RapidERP.Application.Interfaces.Country;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.ActionTypeModels;
using RapidERP.Domain.Entities.CountryModels;
using RapidERP.Domain.Entities.CurrencyModels;
using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Entities.MenuModuleModels;
using RapidERP.Domain.Entities.TenantModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.CQRS.CountryModule.Query.CountryMasterQueries.GetHistoryQuery;

//public class GetHistoryCountryHandler(IRepository repository)
public class GetHistoryCountryHandler(ICountry service)
{
    RequestResponse requestResponse;

    public async Task<RequestResponse> Handle(GetHistoryCountryCommand query)
    {
        //try
        //{
        //    GetHistoryDTO result = new();

        //    var data = (from ch in repository.Set<CountryAudit>()
        //                join c in repository.Set<Country>() on ch.CountryId equals c.Id
        //                //join et in repository.Set<ExportType>() on ca.ExportTypeId equals et.Id
        //                join at in repository.Set<ActionType>() on ch.ActionTypeId equals at.Id
        //                join t in repository.Set<Tenant>() on ch.TenantId equals t.Id
        //                join l in repository.Set<Language>() on ch.LanguageId equals l.Id
        //                join mm in repository.Set<MenuModule>() on ch.MenuModuleId equals mm.Id
        //                join cu in repository.Set<Currency>() on ch.CurrencyId equals cu.Id
        //                select new  
        //                {
        //                    ch.Id,
        //                    Country = c.Name,
        //                    Tanent = t.Name,
        //                    MenuModule = mm.Name,
        //                    Action = at.Name,
        //                    Language = l.Name,
        //                    //ExportType = et.Name,
        //                    Currency = cu.Name,
        //                    ch.ExportTo,
        //                    ch.SourceURL,
        //                    ch.DialCode,
        //                    ch.Name,
        //                    ch.IsDefault,
        //                    ch.IsDraft,
        //                    ch.ISONumeric,
        //                    ch.ISO2Code,
        //                    ch.ISO3Code,
        //                    ch.FlagURL,
        //                    ch.Browser,
        //                    ch.Location,
        //                    ch.DeviceIP,
        //                    ch.LocationURL,
        //                    ch.DeviceName,
        //                    ch.Latitude,
        //                    ch.Longitude,
        //                    ch.ActionBy,
        //                    ch.ActionAt
        //                }).AsNoTracking().AsQueryable();

        //    //int totalItems = await repository.Set<CountryHistory>().CountAsync();
        //    //int totalPages = (totalItems + query.pageSize - 1) / query.pageSize;

        //    if (query.skip == 0 || query.take == 0)
        //    {
        //        //result.TotalCount = totalItems;
        //        //result.TotalPages = totalPages;
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
        //        //result.TotalCount = totalItems;
        //        //result.TotalPages = totalPages;
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

        
        return requestResponse;
    }
}
