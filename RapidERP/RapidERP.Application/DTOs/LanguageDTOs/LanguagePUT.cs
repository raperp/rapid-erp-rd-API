namespace RapidERP.Application.DTOs.LanguageDTOs;
public class LanguagePUT 
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ISO2Code { get; set; }
    public string ISO3Code { get; set; }
    public string ISONumeric { get; set; }
    public string Icon { get; set; }
    public long UpdatedBy { get; set; }
    public string ExportTo { get; set; }
    public string SourceURL { get; set; }
    public int ExportTypeId { get; set; }
    public int ActionTypeId { get; set; }
    public int StatusTypeId { get; set; }
    public string Browser { get; set; }
    public string Location { get; set; }
    public string DeviceIP { get; set; }
    public string GoogleMapUrl { get; set; }
    public string DeviceName { get; set; }
    public decimal Latitude { get; set; } // (9, 6)   
    public decimal Longitude { get; set; } // (9, 6)
}
