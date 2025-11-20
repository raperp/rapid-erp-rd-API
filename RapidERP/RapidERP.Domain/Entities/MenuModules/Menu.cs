using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Domain.Entities.MenuModules;

public class Menu : BaseMaster
{
    public int? SubModuleId { get; set; }
    public string Prefix { get; set; }
    public string IconURL { get; set; }
}
