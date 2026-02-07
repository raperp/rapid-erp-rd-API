using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Domain.Entities.CurrencyModels;

public class CurrencyHistory : BaseAudit
{
    public Currency Currency { get; set; }
    public int CurrencyId { get; set; } 
    public string Code { get; set; }
    public string Icon { get; set; }
}
