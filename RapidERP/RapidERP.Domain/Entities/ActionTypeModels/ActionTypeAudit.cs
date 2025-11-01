using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Domain.Entities.ActionTypeModels;

public class ActionTypeAudit : Master 
{
    public ActionType ActionType { get; set; }
    public int ActionTypeId { get; set; }
    public string Description { get; set; }
}
