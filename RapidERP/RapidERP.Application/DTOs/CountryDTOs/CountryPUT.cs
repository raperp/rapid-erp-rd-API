using RapidERP.Application.DTOs.Shared;

namespace RapidERP.Application.DTOs.CountryDTOs;

public record CountryPUT : BasePUT
{
    //public int Id { get; set; }
    //public int? CurrencyId { get; set; }
    public string DialCode { get; set; }
    public string ISONumeric { get; set; }
    public string ISO2Code { get; set; }
    public string ISO3Code { get; set; }
    public string FlagURL { get; set; }
    public int? RegionId { get; set; }
    public int? StateId { get; set; }
    public int? TimeZoneId { get; set; }
    //public string Name { get; set; }
    //public int? MenuModuleId { get; set; }
    //public int? TenantId { get; set; }
    //public int? StatusTypeId { get; set; }
    //public int? LanguageId { get; set; }
    public bool IsDefault { get; set; }
    public bool IsDraft { get; set; }
    //public int? ActionTypeId { get; set; }
    //public int? ExportTypeId { get; set; }
    //public string ExportTo { get; set; }
    //public string SourceURL { get; set; }
    //public string Browser { get; set; }
    //public string Location { get; set; }
    //public string DeviceIP { get; set; }
    //public string LocationURL { get; set; }
    //public string DeviceName { get; set; }
    //public decimal Latitude { get; set; } // (9, 6)   
    //public decimal Longitude { get; set; } // (9, 6)   
    //public int ActionBy { get; set; }
}
