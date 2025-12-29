using RapidERP.Application.DTOs.Shared;

namespace RapidERP.Application.DTOs.OrderTypeDTOs;
public record class OrderTypePUT : BasePUT
{
    public string Description { get; set; }
    public bool IsDefault { get; set; }
    public bool IsDraft { get; set; }
}
