using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Domain.Entities.CalendarModels;

public class CalendarHistory : BaseHistory
{
    public Calendar Calendar { get; set; }
    public int? CalendarId { get; set; }
    public string Code { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int TotalMonth { get; set; }
}
