using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Domain.Entities.MenuModules;

public class MenuAudit : BaseAudit
{
    public Menu Menu { get; set; }
    public int MenuId { get; set; }
    public int? SubModuleId { get; set; }
    public string Prefix { get; set; }
    public string IconURL { get; set; }
}
