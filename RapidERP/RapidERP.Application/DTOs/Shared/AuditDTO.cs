namespace RapidERP.Application.DTOs.Shared;
public class AuditDTO : TrackerDTO
{
    public string Name { get; set; }
    public string ExportTo { get; set; }
    public string SourceURL { get; set; }
    public int ExportTypeId { get; set; }
    public int ActionTypeId { get; set; }
    public int StatusTypeId { get; set; }
    public bool IsDefault { get; set; }
}
