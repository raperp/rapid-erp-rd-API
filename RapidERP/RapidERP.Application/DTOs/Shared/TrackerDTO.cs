namespace RapidERP.Application.DTOs.Shared;

public class TrackerDTO 
{
    public int ExportTypeId { get; set; }
    public string ExportTo { get; set; }
    public string SourceURL { get; set; }
    public string Browser { get; set; }
    public string Location { get; set; }
    public string DeviceIP { get; set; }
    public string GoogleMapUrl { get; set; }
    public string DeviceName { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    public long ActionBy { get; set; }
    public DateTime ActionAt { get; set; }
}
