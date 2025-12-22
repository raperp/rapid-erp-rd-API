using RapidERP.Application.Features.CountryFeatures.GetSingleCountry;
using RapidERP.Application.Repository;
using RapidERP.Domain.Entities.CountryModels;
using RapidERP.Domain.Entities.CurrencyModels;
using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Entities.MenuModuleModels;
using RapidERP.Domain.Entities.StatusTypeModels;
using RapidERP.Domain.Entities.TenantModels;

namespace RapidERP.Application.Features.CountryFeatures.GetSingleQuery;

public class GetSingleCountryHandler(IRepository repository)
{
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
                        select new GetSingleCountryResponseModel
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
                        }).Where(x => x.Id == id).SingleOrDefault();

            return data;
        }

        catch (Exception ex)
        {
            throw new ApplicationException(ex.Message);
        }
    }
}
