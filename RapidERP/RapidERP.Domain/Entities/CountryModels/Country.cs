using RapidERP.Domain.Entities.CurrencyModels;
using RapidERP.Domain.Entities.Shared;
using RapidERP.Domain.Entities.TenantModels;

namespace RapidERP.Domain.Entities.CountryModels;

public class Country : BaseMaster
{
    public Currency Currency { get; set; }
    public int? CurrencyId { get; set; }
    public string ISONumeric { get; set; }
    public string DialCode { get; set; }
    public string ISO2Code { get; set; }
    public string ISO3Code { get; set; }
    public string FlagURL { get; set; }
    public ICollection<Tenant> Tenants { get; set; }
}
