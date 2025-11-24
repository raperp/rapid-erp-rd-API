using RapidERP.Domain.Entities.Shared;
using RapidERP.Domain.Entities.SubmoduleModels;

namespace RapidERP.Domain.Entities.MenuModules;

public class Menu : BaseMaster
{
    public Submodule Submodule { get; set; }
    public int SubmoduleId { get; set; }
    public string Prefix { get; set; }
    public string IconURL { get; set; }
}
