using RapidERP.Domain.Entities.CountryModels;
using RapidERP.Domain.Entities.Shared;
using RapidERP.Domain.Entities.TenantModels;

namespace RapidERP.Domain.Entities.SateModules;

public class State : BaseMaster
{
    public Country Country { get; set; }
    public int CountryId { get; set; }
    public string Code { get; set; }
    public ICollection<Tenant> Tenants { get; set; }
}
