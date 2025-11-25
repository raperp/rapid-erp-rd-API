using RapidERP.Domain.Entities.Shared;
using RapidERP.Domain.Entities.TenantModels;

namespace RapidERP.Domain.Entities.LanguageModels;

public class Language : BaseMaster
{
    public string ISONumeric { get; set; }
    public string ISO2Code { get; set; }
    public string ISO3Code { get; set; }
    public string IconURL { get; set; }
    public ICollection<Tenant> Tenants { get; set; }
}
