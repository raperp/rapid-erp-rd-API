using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Domain.Entities.ActionTypeModels;

public class ActionType : BaseMaster
{
    public int? TenantId { get; set; }
    public string Description { get; set; }
}
