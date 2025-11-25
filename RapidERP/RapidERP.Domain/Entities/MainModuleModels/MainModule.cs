using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Domain.Entities.MainModuleModels;

public class MainModule : BaseMaster
{
     
    public string Prefix { get; set; }
    public string IconURL { get; set; }
    public string SetSerial { get; set; }
}
