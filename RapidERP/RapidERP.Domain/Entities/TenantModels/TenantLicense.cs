using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Domain.Entities.TenantModels;

public class TenantLicense : Master
{
    public Tenant Tenant { get; set; }
    public int? TenantId { get; set; }
    public string LicenseNumber { get; set; }
    public string LimitUsers { get; set; }
    public string ERPPlan { get; set; }
    public DateTime IssueAt { get; set; }
    public string ValidityDays { get; set; }
    public DateTime ExpiryAt { get; set; }
    public DateTime ReminderAt { get; set; }
}
