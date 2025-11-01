using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Domain.Entities.ActionTypeModels;

public class ActionTypeTracker : Tracker
{
    public ActionType ActionType { get; set; }
    public int ActionTypeId { get; set; }
}
