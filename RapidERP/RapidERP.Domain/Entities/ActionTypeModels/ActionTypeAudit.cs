using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Domain.Entities.ActionTypeModels;

public class ActionTypeAudit : BaseAudit 
{
    public ActionType ActionType { get; set; }
    public int? ActionTypeId { get; set; }
    public Language Language { get; set; }
    public int? LanguageId { get; set; }
    public string Description { get; set; }
}
