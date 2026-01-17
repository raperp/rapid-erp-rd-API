using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Domain.Entities.CurrencyModels;

public class CurrencyTemplate : Master
{
    public string Code { get; set; }
    public string Icon { get; set; }
}
