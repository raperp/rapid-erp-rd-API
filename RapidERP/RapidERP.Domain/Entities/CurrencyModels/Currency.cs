using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Domain.Entities.CurrencyModels;
public class Currency : BaseMaster
{
    public int? MenuId { get; set; }
    public Language Language { get; set; }
    public int LanguageId { get; set; }
    public string Code { get; set; }
    public string Icon { get; set; }
    public bool IsDefault { get; set; }
}
