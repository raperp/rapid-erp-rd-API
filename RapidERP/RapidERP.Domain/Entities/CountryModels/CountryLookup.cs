namespace RapidERP.Domain.Entities.CountryModels;

public class CountryLookup
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string ISONumeric { get; set; }
    public string ISO2Code { get; set; }
    public string ISO3Code { get; set; }
}
