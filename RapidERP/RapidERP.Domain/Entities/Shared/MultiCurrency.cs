using RapidERP.Domain.Entities.CurrencyModels;

namespace RapidERP.Domain.Entities.Shared;

public class MultiCurrency : Master
{
    public Currency Currency { get; set; }
    public int? CurrencyId { get; set; }
}
