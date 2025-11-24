namespace RapidERP.Domain.Entities.Shared;

public class Tracker : Master
{
    public string Browser { get; set; }
    public string Location { get; set; }
    public string DeviceIP { get; set; }
    public string GoogleMapURL { get; set; }
    public string DeviceName { get; set; }
    public decimal Latitude { get; set; } // (9, 6)   
    public decimal Longitude { get; set; } // (9, 6)   
    public int ActionBy { get; set; }
    public DateTime ActionAt { get; set; }
}
