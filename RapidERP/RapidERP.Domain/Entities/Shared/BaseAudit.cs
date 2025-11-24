namespace RapidERP.Domain.Entities.Shared;

public class BaseAudit : Tracker
{
    public int? ActionTypeId { get; set; }
    public int? ExportTypeId { get; set; }
    public string ExportTo { get; set; }
    public string SourceURL { get; set; }
}
