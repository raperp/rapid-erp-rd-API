using RapidERP.Application.DTOs.Shared;

namespace RapidERP.Application.DTOs.OrderTypeDTOs;
public record class OrderTypePOST : BasePOST
{
    public string Description { get; set; }
    public bool IsDefault { get; set; }
    public bool IsDraft { get; set; }
}
