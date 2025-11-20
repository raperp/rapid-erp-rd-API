using RapidERP.Domain.Entities.MainModuleModels;
using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Domain.Entities.SubmoduleModels;

public class Submodule : BaseMaster
{
    public MainModule MainModule { get; set; }
    public int MainModuleId { get; set; }
    public string Prefix { get; set; }
}
