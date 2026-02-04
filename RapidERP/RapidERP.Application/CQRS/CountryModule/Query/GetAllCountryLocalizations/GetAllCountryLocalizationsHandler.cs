using Microsoft.EntityFrameworkCore;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.CountryModels;
using RapidERP.Domain.Entities.CurrencyModels;
using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Entities.MenuModuleModels;
using RapidERP.Domain.Entities.StatusTypeModels;
using RapidERP.Domain.Entities.TenantModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.CQRS.CountryModule.Query.GetAllCountryLocalizations;

public class GetAllCountryLocalizationsHandler(IRepository repository)
{
    RequestResponse requestResponse;

    public async Task<RequestResponse> Handle(GetAllCountryLocalizationsCommand request)
    {
        try
        {
            var data = (from cl in repository.Set<CountryLocalization>()
                        join c in repository.Set<Country>() on cl.CountryId equals c.Id
                        join l in repository.Set<Language>() on cl.LanguageId equals l.Id
                        select new
                        {
                            cl.Id,
                            cl.Name,
                            Language = l.Name,
                            Country = c.Name
                        }).AsNoTracking().AsQueryable();

            var result = await data.ToListAsync();

            requestResponse = new()
            {
                StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
                IsSuccess = true,
                Message = ResponseMessage.FetchSuccess,
                Data = result
            };

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
