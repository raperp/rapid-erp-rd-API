using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Domain.Entities.TenantModels;

public class TenantCalendar : Master
{
    public Tenant Tenant { get; set; }
    public int? TenantId { get; set; }
    public int? CalendarId { get; set; }
    public int? DefaultCalendarId { get; set; }
}