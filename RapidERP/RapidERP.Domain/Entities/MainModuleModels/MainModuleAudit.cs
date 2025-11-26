using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Domain.Entities.MainModuleModels;

public class MainModuleAudit : BaseAudit
{
    public MainModule MainModule { get; set; }
    public int MainModuleId { get; set; }
    public string Prefix { get; set; }
    public string IconURL { get; set; }
    public int SetSerial { get; set; }
}
