using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Domain.Entities.OrderTypeModels;
public class OrderTypeHistory : BaseHistory
{
    public OrderType OrderType { get; set; }
    public int OrderTypeId { get; set; }
    public string Description { get; set; }
}
