using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Domain.Entities.ActionTypeModels;
public class ActionTypeAudit : BaseAudit 
{
    public string Description { get; set; }
}
