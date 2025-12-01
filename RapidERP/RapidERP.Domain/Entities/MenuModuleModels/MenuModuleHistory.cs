using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Domain.Entities.MenuModuleModels;

public class MenuModuleHistory : BaseHistory
{
    public MenuModule MenuModule { get; set; }
    public int? MenuModuleId { get; set; }
    public int? SubmoduleId { get; set; }
    public string IconURL { get; set; }
    public int SetSerial { get; set; }
}
