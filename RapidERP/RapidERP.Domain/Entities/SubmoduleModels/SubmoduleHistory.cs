using RapidERP.Domain.Entities.MainModuleModels;
using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Domain.Entities.SubmoduleModels;

public class SubmoduleHistory : BaseAudit
{
    public Submodule Submodule { get; set; }
    public int SubmoduleId { get; set; }
    public int MainModuleId { get; set; }
    public string IconURL { get; set; }
    public int SetSerial { get; set; }
}
