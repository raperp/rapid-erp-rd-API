using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Domain.Entities.CountryModels;

public class CountryTemplate : Master
{
    public string ISONumeric { get; set; }
    public string DialCode { get; set; }
    public string ISO2Code { get; set; }
    public string ISO3Code { get; set; }
}
