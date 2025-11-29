using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Domain.Entities.ExportTypeModels;

public class ExportTypeAudit : BaseHistory
{
    public ExportType ExportType { get; set; }
    public int? ExportTypeId { get; set; }
    public Language Language { get; set; }
    public int? LanguageId { get; set; }
    public string Description { get; set; }
}
