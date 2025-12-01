using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Domain.Entities.KitchenModels;

public class KitchenHistory : BaseHistory
{
    public Kitchen Kitchen { get; set; }
    public int KitchenId { get; set; }
    public int? PrinterId { get; set; }
    public string Description { get; set; }
}
