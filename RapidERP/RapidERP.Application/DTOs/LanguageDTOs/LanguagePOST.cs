namespace RapidERP.Application.DTOs.LanguageDTOs;

public class LanguagePOST  
{
    public string ISONumeric { get; set; }
    public string Name { get; set; }
    public string ISO2Code { get; set; }
    public string ISO3Code { get; set; }
    public string IconURL { get; set; }
    public string Browser { get; set; }
    public string Location { get; set; }
    public string DeviceIP { get; set; }
    public string LocationURL { get; set; }
    public string DeviceName { get; set; }
    public decimal Latitude { get; set; } // (9, 6)   
    public decimal Longitude { get; set; } // (9, 6)
    public bool IsDraft { get; set; }
    public int ActionBy { get; set; }
}
