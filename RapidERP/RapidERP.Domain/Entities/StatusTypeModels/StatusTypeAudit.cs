using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Domain.Entities.StatusTypeModels;
public class StatusTypeAudit : BaseAudit
{
    public int? LanguageId { get; set; }
    public string Description { get; set; }
}
