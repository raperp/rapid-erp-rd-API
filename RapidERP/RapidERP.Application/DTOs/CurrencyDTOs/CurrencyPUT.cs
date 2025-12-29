using RapidERP.Application.DTOs.Shared;

namespace RapidERP.Application.DTOs.CurrencyDTOs;

public record class CurrencyPUT : BasePUT
{
    public string Code { get; set; }
    public string Icon { get; set; }
    public bool IsDefault { get; set; }
    public bool IsDraft { get; set; }
}
