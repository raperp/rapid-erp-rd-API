namespace RapidERP.Application.DTOs.ExportTypeDTOs;
public class ExportTypePUT  
{
    public int Id { get; set; }
    public int LanguageId { get; set; }
    public string Name { get; set; }
    public long UpdatedBy { get; set; }
    public string Description { get; set; }

    public string Browser { get; set; }
    public string Location { get; set; }
    public string DeviceIP { get; set; }
    public string GoogleMapUrl { get; set; }
    public string DeviceName { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
}
