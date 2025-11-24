namespace RapidERP.Application.DTOs.Shared;

public class AuditDTO : TrackerDTO
{
    public int ActionTypeId { get; set; }
    public int ExportTypeId { get; set; }
    public string ExportTo { get; set; }
    public string SourceURL { get; set; }
    public bool IsDefault { get; set; }
}