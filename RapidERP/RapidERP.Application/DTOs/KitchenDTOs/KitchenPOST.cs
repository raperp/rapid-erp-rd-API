using RapidERP.Application.DTOs.Shared;

namespace RapidERP.Application.DTOs.KitchenDTOs;

public record class KitchenPOST : BasePOST
{
    public int PrinterId { get; set; }
    public string Description { get; set; }
}
