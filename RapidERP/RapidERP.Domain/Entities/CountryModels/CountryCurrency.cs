using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Domain.Entities.CountryModels;

public class CountryCurrency : MultiCurrency
{
    public Country Country { get; set; }
    public int? CountryId { get; set; }
}
