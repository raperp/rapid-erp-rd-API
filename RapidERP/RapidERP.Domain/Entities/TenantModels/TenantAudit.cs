using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Domain.Entities.TenantModels;

public class TenantAudit : BaseHistory
{
    public Tenant Tenant { get; set; }
    //public int? TenantId { get; set; }
    public int? CountryId { get; set; }
    public int? StateId { get; set; }
    public string Contact { get; set; }
    public string Phone { get; set; }
    public string Mobile { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public string Website { get; set; }
}
