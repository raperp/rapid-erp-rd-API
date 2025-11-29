using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Domain.Entities.CurrencyModels;
public class CurrencyAudit : BaseHistory
{
    public Currency Currency { get; set; }
    public int CurrencyId { get; set; }
    public int? MenuId { get; set; }
    public int? LanguageId { get; set; }
    public string Code { get; set; }
    public string Icon { get; set; }
}
