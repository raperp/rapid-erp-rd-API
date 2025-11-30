using RapidERP.Application.DTOs.Shared;

namespace RapidERP.Application.DTOs.TenantDTOs.TenantCalendarDTOs;

public class TenantCalendarPUT : TrackerDTO
{
    public int Id { get; set; }
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
    public int DefaultCalendarId { get; set; }
}
