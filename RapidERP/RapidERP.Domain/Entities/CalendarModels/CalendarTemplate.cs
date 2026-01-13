using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Domain.Entities.CalendarModels;

public class CalendarTemplate : Master
{
    public string Code { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int TotalMonth { get; set; }
}
