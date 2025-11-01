using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Domain.Entities.LanguageModels;
public class LanguageTracker  
{
    public int Id { get; set; }
    public Language Language { get; set; }
    public int LanguageId { get; set; }
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
