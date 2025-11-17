using RapidERP.Application.DTOs.Shared;

namespace RapidERP.Application.DTOs.KitchenDTOs;

public class KitchenPUT : BasePUT
{
    public int PrinterId { get; set; }
    public string Description { get; set; }
}
