namespace RapidERP.Application.Features.CalendarFeatures.GetHistoryQuery;

public record GetHistoryCalendarResponseDTOModel
{
    public int Id { get; set; }
    public string Currency { get; set; }
    public string Tenant { get; set; }
    public string MenuModule { get; set; }
    public string Language { get; set; }
    public string Action { get; set; }
    public string ExportType { get; set; }
    public string ExportTo { get; set; }
    public string SourceURL { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int TotalMonth { get; set; }
    public string Browser { get; set; }
    public string Location { get; set; }
    public string DeviceIP { get; set; }
    public string LocationURL { get; set; }
    public string DeviceName { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
    public int ActionBy { get; set; }
    public DateTime ActionAt { get; set; }
}
