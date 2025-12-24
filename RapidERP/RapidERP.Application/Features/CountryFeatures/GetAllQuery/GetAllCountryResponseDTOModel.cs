namespace RapidERP.Application.Features.CountryFeatures.GetAllQuery;

public record GetAllCountryResponseDTOModel
{
    public int Id { get; set; }
    public string MenuModule { get; set; }
    public string Tanent { get; set; }
    public string Language { get; set; }
    public string Status { get; set; }
    public string Currency { get; set; }
    public string DialCode { get; set; }
    public string Country { get; set; }
    public bool IsDefault { get; set; }
    public bool IsDraft { get; set; }
    public string ISONumeric { get; set; }
    public string ISO2Code { get; set; }
    public string ISO3Code { get; set; }
    public string FlagURL { get; set; }
}
