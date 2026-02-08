using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Domain.Entities.TenantModels;

public class TenantHistory : BaseAudit
{
    public Tenant Tenant { get; set; }
    public int? TenantId { get; set; }
    public int? CountryId { get; set; }
    public int? StateId { get; set; }
    public int? CalendarId { get; set; }
    public string Contact { get; set; }
    public string Phone { get; set; }
    public string Mobile { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public string Website { get; set; }
    public string LicenseNumber { get; set; }
    public string LimitUsers { get; set; }
    public string ERPPlan { get; set; }
    public DateTime? IssueAt { get; set; }
    public string ValidityDays { get; set; }
    public DateTime? ExpiryAt { get; set; }
    public DateTime? ReminderAt { get; set; }
    public int? InterfaceLanguageId { get; set; }
    public int? DataLanguageId { get; set; }
    public int? DefaultLanguageId { get; set; }
    public int? DefaultCalendarId { get; set; }
}
