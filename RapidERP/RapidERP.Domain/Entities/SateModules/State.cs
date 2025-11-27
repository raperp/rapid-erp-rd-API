using RapidERP.Domain.Entities.CountryModels;
using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Entities.Shared;
using RapidERP.Domain.Entities.TenantModels;

namespace RapidERP.Domain.Entities.SateModules;

public class State : BaseMaster
{
    public Country Country { get; set; }
    public int CountryId { get; set; }
    public int? MenuId { get; set; }
    public Language Language { get; set; }
    public int LanguageId { get; set; }
    public string Code { get; set; }
    public bool IsDefault { get; set; }
    public ICollection<Tenant> Tenants { get; set; }
}
