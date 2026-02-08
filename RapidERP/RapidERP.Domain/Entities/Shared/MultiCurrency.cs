using RapidERP.Domain.Entities.CurrencyModels;

namespace RapidERP.Domain.Entities.Shared;

public class MultiCurrency
{
    public int Id { get; set; }
    public Currency Currency { get; set; }
    public int? CurrencyId { get; set; }
}
