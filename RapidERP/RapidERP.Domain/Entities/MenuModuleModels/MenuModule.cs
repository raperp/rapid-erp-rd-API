using RapidERP.Domain.Entities.Shared;
using RapidERP.Domain.Entities.SubmoduleModels;
using RapidERP.Domain.Entities.TenantModels;

namespace RapidERP.Domain.Entities.MenuModuleModels;

public class MenuModule : BaseMaster
{
    public Submodule Submodule { get; set; }
    public int? SubmoduleId { get; set; }
    public string IconURL { get; set; }
    public int SetSerial { get; set; }
    
    //public ICollection<Submodule> Submodules { get; }
    public ICollection<Tenant> Tenants { get; }
}
