using RapidERP.Application.DTOs.Shared;

namespace RapidERP.Application.DTOs.TenantDTOs.TenantDTOs;

public class TenantPOST : TrackerDTO
{ 
    public int CalendarId { get; set; }    
    public string Contact { get; set; }
    public string Phone { get; set; }
    public string Mobile { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public string Website { get; set; }
    public int CountryId { get; set; }
    public int StateId { get; set; }
    public string Name { get; set; }
    public int? MenuModuleId { get; set; }
    public int? TenantId { get; set; }
    public int StatusTypeId { get; set; }
    public int? LanguageId { get; set; }
    public bool IsDefault { get; set; }
    public bool IsDraft { get; set; }
    public int? ActionTypeId { get; set; }
    public int? ExportTypeId { get; set; }
    public string ExportTo { get; set; }
    public string SourceURL { get; set; }
}
