using RapidERP.Domain.Entities.Shared;
using RapidERP.Domain.Entities.TenantModels;

namespace RapidERP.Domain.Entities.MenuModuleModels;

public class MenuModule : BaseMaster
{
    public int? SubmoduleId { get; set; }
    public string IconURL { get; set; }
    public int SetSerial { get; set; }
    
    //public ICollection<Submodule> Submodules { get; }
    public ICollection<Tenant> Tenants { get; }
}
