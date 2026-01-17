using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Domain.Entities.TenantModels;

public class TenantTemplate : Master
{
    public string Mobile { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public string Website { get; set; }
}
