using RapidERP.Application.DTOs.Shared;

namespace RapidERP.Application.DTOs.TenantDTOs.TenantLanguageDTOs;

public class TenantLanguagePOST : TrackerDTO
{
    public int TenantId { get; set; }
    public int MenuModuleId { get; set; }
    public int CountryId { get; set; }
    public int StateId { get; set; }
    public int LanguageId { get; set; }
    public int CalendarId { get; set; }
    public int ActionTypeId { get; set; }
    public int ExportTypeId { get; set; }
    public string ExportTo { get; set; }
    public string SourceURL { get; set; }
    public int InterfaceLanguageId { get; set; }
    public int DataLanguageId { get; set; }
    public int DefaultLanguageId { get; set; }
}
