using RapidERP.Application.DTOs.Shared;

namespace RapidERP.Application.DTOs.CurrencyDTOs;

public record class CurrencyPOST : BasePOST
{ 
    public string Code { get; set; }
    public string Icon { get; set; }
    public bool IsDefault { get; set; }
    public bool IsDraft { get; set; }
}
