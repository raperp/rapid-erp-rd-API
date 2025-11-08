using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Domain.Entities.ExportTypeModels;
public class ExportTypeAudit : BaseAudit
{
    public int? LanguageId { get; set; }
    public string Description { get; set; }
}
