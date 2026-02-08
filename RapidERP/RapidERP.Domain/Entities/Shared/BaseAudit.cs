namespace RapidERP.Domain.Entities.Shared;

public class BaseAudit : Master
{
    //public int? TenantId { get; set; }
    public int? StatusTypeId { get; set; }
    public int? ActionTypeId { get; set; }
    public int? LanguageId { get; set; }
    //public int? ExportTypeId { get; set; }
    //public string ExportTo { get; set; }
    //public string SourceURL { get; set; }
    public string Code { get; set; }
    public bool IsDefault { get; set; }
    public bool IsDraft { get; set; }
    public int ActionBy { get; set; }
    public DateTime ActionAt { get; set; }
}