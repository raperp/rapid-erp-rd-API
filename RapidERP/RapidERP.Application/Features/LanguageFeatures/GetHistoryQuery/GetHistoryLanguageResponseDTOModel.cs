namespace RapidERP.Application.Features.LanguageFeatures.GetHistoryQuery;

public record GetHistoryLanguageResponseDTOModel
{
    public int Id { get; set; }
    public string Language { get; set; }
    public string ISONumeric { get; set; }
    public string Name { get; set; }
    public string ISO2Code { get; set; }
    public string ISO3Code { get; set; }
    public string IconURL { get; set; }
    public string Browser { get; set; }
    public string Location { get; set; }
    public string DeviceIP { get; set; }
    public string LocationURL { get; set; }
    public string DeviceName { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    public int ActionBy { get; set; }
    public DateTime ActionAt { get; set; }
}
