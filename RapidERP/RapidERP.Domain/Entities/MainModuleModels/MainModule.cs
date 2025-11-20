using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Domain.Entities.MainModuleModels;

public class MainModule : BaseMaster
{
    public Language Language { get; set; }
    public int LanguageId { get; set; }
    public string Prefix { get; set; }
    public string IconURL { get; set; }
}
