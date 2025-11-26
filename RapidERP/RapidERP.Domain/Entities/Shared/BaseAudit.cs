namespace RapidERP.Domain.Entities.Shared;

public class BaseAudit : Tracker
{
    public int? TenantId { get; set; }
    public int? MenuModuleId { get; set; }
    public int? ActionTypeId { get; set; }
    public int? LanguageId { get; set; }
    public int? ExportTypeId { get; set; }
    public string ExportTo { get; set; }
    public string SourceURL { get; set; }
    public bool IsDefault { get; set; }
    public bool IsDraft { get; set; }
}
