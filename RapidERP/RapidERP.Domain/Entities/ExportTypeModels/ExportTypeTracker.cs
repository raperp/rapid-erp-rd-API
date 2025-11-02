namespace RapidERP.Domain.Entities.ExportTypeModels;
public class ExportTypeTracker  
{
    public int Id { get; set; }
    public ExportType ExportType { get; set; }
    public int ExportTypeId { get; set; }
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
