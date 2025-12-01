using RapidERP.Application.DTOs.Shared;

namespace RapidERP.Application.DTOs.CalendarDTOs;

public class CalendarPUT : TrackerDTO
{
    public int Id { get; set; }
    public string Code { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int TotalMonth { get; set; }
    public string Name { get; set; }
    public int MenuModuleId { get; set; }
    public int TenantId { get; set; }
    public int StatusTypeId { get; set; }
    public int LanguageId { get; set; }
    public bool IsDefault { get; set; }
    public bool IsDraft { get; set; }
    public int ActionTypeId { get; set; }
    public int ExportTypeId { get; set; }
    public string ExportTo { get; set; }
    public string SourceURL { get; set; }
}
