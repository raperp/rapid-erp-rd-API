namespace RapidERP.Application.Features.CityFeatures.GetHistoryQuery;

public record GetHistoryCityResponseDTOModel
{
    public int Id { get; set; }
    public string City { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public string Tanent { get; set; }
    public string Menu { get; set; }
    public string Action { get; set; }
    public string Language { get; set; }
    public string ExportType { get; set; }
    public string ExportTo { get; set; }
    public string SourceURL { get; set; }
    public bool IsDefault { get; set; }
    public bool IsDraft { get; set; }
    public string Browser { get; set; }
    public string Location { get; set; }
    public string DeviceIP { get; set; }
    public string LocationURL { get; set; }
    public string DeviceName { get; set; }
    public decimal? Latitude { get; set; }
    public decimal? Longitude { get; set; }
    public int ActionBy { get; set; }
    public DateTime ActionAt { get; set; }
}
