using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Domain.Entities.ExportTypeModels;

public class ExportTypeHistory : BaseAudit
{
    public ExportType ExportType { get; set; }
    public int? ExportTypeId { get; set; }
    public string Description { get; set; }
}
