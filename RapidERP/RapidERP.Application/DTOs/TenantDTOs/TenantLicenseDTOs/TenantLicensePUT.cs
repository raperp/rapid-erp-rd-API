using RapidERP.Application.DTOs.Shared;

namespace RapidERP.Application.DTOs.TenantDTOs.TenantLicenseDTOs;

public record class TenantLicensePUT : TrackerDTO
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
    public string LicenseNumber { get; set; }
    public string LimitUsers { get; set; }
    public string ERPPlan { get; set; }
    public DateTime IssueAt { get; set; }
    public string ValidityDays { get; set; }
    public DateTime ExpiryAt { get; set; }
    public DateTime ReminderAt { get; set; }
    public string ExportTo { get; set; }
    public string SourceURL { get; set; }
}
