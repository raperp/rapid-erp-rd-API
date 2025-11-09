using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Domain.Entities.CountryModels;
public class Country : BaseMaster
{
    //public Tenant Tenant { get; set; } 
    public int? TenantId { get; set; } 
    public int MenuId { get; set; }
    public Language Language { get; set; }
    public int LanguageId { get; set; }
    public string ISONumeric { get; set; }
    public string DialCode { get; set; }
    public string ISO2Code { get; set; }
    public string ISO3Code { get; set; }
    public string FlagURL { get; set; }
    public bool IsDefault { get; set; }
}
