namespace RapidERP.Application.DTOs.ActionTypeDTOs;
public class ActionTypePOST  
{
    public string Name { get; set; }
    public int ExportTypeId { get; set; }
    public int LanguageId { get; set; }
    public int StatusTypeId { get; set; }
    public string Description { get; set; }
    public long CreatedBy { get; set; }
    public string ExportTo { get; set; }
    public string SourceURL { get; set; }
    public bool IsDefault { get; set; }
    public string Browser { get; set; }
    public string Location { get; set; }
    public string DeviceIP { get; set; }
    public string GoogleMapUrl { get; set; }
    public string DeviceName { get; set; }
    public decimal Latitude { get; set; } // (9, 6)   
    public decimal Longitude { get; set; } // (9, 6)
}
