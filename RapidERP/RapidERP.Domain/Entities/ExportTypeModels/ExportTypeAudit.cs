using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Domain.Entities.ExportTypeModels;

public class ExportTypeAudit : BaseHistory
{
    public ExportType ExportType { get; set; }
    public string Description { get; set; }
}
