using RapidERP.Application.DTOs.Shared;

namespace RapidERP.Application.DTOs.CurrencyDTOs;

public record class CurrencyPOST : BasePOST
{  
    public string Icon { get; set; } 
}
