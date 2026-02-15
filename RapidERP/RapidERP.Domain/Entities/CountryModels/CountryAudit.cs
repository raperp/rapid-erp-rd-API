using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Domain.Entities.CountryModels;

public class CountryAudit : BaseAudit
{
    public Country Country { get; set; }
    public int CountryId { get; set; }
    public int? CurrencyId { get; set; }
    public int? DefaultCurrencyId { get; set; }
    public string ISONumeric { get; set; }
    public string ISO2Code { get; set; }
    public string ISO3Code { get; set; }
    public string FlagURL { get; set; }
}
