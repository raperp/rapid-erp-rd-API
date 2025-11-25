using RapidERP.Domain.Entities.Shared;
using RapidERP.Domain.Entities.TenantModels;

namespace RapidERP.Domain.Entities.StatusTypeModels;

public class StatusType : BaseMaster
{
    public string Description { get; set; }
    public ICollection<Tenant> Tenants { get; set; }
}
