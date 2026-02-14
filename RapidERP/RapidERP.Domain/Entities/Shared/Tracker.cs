namespace RapidERP.Domain.Entities.Shared;

public class Tracker  
{
    public int Id { get; set; }
    public int? ActivityTypeId { get; set; }
    public DateTime? PageViewStartedAt { get; set; }
    public DateTime? PageViewEndedAt { get; set; }
    public string Browser { get; set; }
    public string Location { get; set; }
    public string LocationURL { get; set; }
    public string DeviceIP { get; set; }
    public string DeviceName { get; set; }
    public string OS { get; set; }
    public decimal Latitude { get; set; } // (9, 6)   
    public decimal Longitude { get; set; } // (9, 6)
}
