using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Domain.Entities.RoleModules;

public class RoleHistory : BaseAudit
{
    public Role Role { get; set; }
    public int RoleId { get; set; }
}
