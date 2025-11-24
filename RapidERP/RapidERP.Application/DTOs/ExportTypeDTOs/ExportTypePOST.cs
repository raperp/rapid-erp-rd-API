namespace RapidERP.Application.DTOs.ExportTypeDTOs;
public class ExportTypePOST 
{
    public string Name { get; set; }
    public int LanguageId { get; set; }
    public string Description { get; set; }
    public int CreatedBy { get; set; } 
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
