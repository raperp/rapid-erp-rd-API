using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Domain.Entities.CountryModels;

public class CountryAudit : BaseHistory
{
    public Country Country { get; set; }
    public int CountryId { get; set; }
    //public int? CurrencyId { get; set; }
    public string ISONumeric { get; set; }
    public string DialCode { get; set; }
    public string ISO2Code { get; set; }
    public string ISO3Code { get; set; }
    public string FlagURL { get; set; }
    public int? RegionId { get; set; }
    public int? StateId { get; set; }
    public int? TimeZoneId { get; set; }
}
