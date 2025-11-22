using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Entities.Shared;
using RapidERP.Domain.Entities.StatusTypeModels;

namespace RapidERP.Domain.Entities.ActionTypeModels;

public class ActionType : BaseMaster
{
    public Language Language { get; set; }
    public int? LanguageId { get; set; }
    public StatusType StatusType { get; set; }
    public int? StatusTypeId { get; set; }
    public string Description { get; set; }
}
