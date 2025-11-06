using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Domain.Entities.ExportTypeModels;
public class ExportTypeAudit : BaseAudit
{
    public string Description { get; set; }
}
