using RapidERP.Application.DTOs.Shared;

namespace RapidERP.Application.DTOs.CurrencyDTOs;

public record class CurrencyPUT : BasePUT
{
    public string Icon { get; set; } 
}
