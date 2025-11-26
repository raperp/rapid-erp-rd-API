using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Domain.Entities.MenuModuleModels;

public class MenuModuleAudit : BaseAudit
{
    public MenuModule Menu { get; set; }
    public int MenuId { get; set; }
    public int? SubModuleId { get; set; }
    public string Prefix { get; set; }
    public string IconURL { get; set; }
}
