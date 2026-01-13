namespace RapidERP.Application.Features.CalendarFeatures.GetAllQuery;

public record GetAllCalendarResponseDTOModel
{
    public int Id { get; set; }
    public string Tenant { get; set; }
    public string MenuModule { get; set; }
    public string Language { get; set; }
    public string Status { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int TotalMonth { get; set; }
}
