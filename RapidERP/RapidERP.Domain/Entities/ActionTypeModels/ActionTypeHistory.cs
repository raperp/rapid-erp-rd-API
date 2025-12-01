using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Domain.Entities.ActionTypeModels;

public class ActionTypeHistory : BaseHistory 
{
    public ActionType ActionType { get; set; }
    public string Description { get; set; }
}
