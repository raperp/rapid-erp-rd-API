using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Domain.Entities.KitchenModels;

public class Kitchen : BaseMaster
{
    public int? PrinterId { get; set; }
    public string Description { get; set; }
}
