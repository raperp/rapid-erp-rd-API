using Microsoft.EntityFrameworkCore;
using RapidERP.Application.Features.CountryFeatures.GetSingleCountry;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.CountryModels;
using RapidERP.Domain.Entities.CurrencyModels;
using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Entities.MenuModuleModels;
using RapidERP.Domain.Entities.StatusTypeModels;
using RapidERP.Domain.Entities.TenantModels;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.CountryFeatures.GetSingleQuery;

public class GetSingleCountryHandler(IRepository repository)
{
    GetSingleCountryResponseModel _response;

    public async Task<GetSingleCountryResponseModel> Handle(int id)
    {
        try
        {
            var data = (from c in repository.Set<Country>()
                        join st in repository.Set<StatusType>() on c.StatusTypeId equals st.Id
                        join t in repository.Set<Tenant>() on c.TenantId equals t.Id
                        join l in repository.Set<Language>() on c.LanguageId equals l.Id
                        join mm in repository.Set<MenuModule>() on c.MenuModuleId equals mm.Id
                        join cu in repository.Set<Currency>() on c.CurrencyId equals cu.Id
                        select new GetSingleCountryResponseDTOModel
                        {
                            Id = c.Id,
                            MenuModule = mm.Name,
                            Tanent = t.Name,
                            Language = l.Name,
                            Status = st.Name,
                            Currency = cu.Name,
                            DialCode = c.DialCode,
                            Country = c.Name,
                            IsDefault = c.IsDefault,
                            IsDraft = c.IsDraft,
                            ISONumeric = c.ISONumeric,
                            ISO2Code = c.ISO2Code,
                            ISO3Code = c.ISO3Code,
                            FlagURL = c.FlagURL
                        }).Where(x => x.Id == id).AsNoTracking().ToListAsync();

            _response = new()
            {
                StatusCode = $"{HTTPStatusCode.OK} {HTTPStatusCode.StatusCode200}",
                IsSuccess = true,
                Message = ResponseMessage.FetchSuccess,
                Data = data
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
