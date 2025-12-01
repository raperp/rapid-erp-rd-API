using RapidERP.Application.DTOs.Shared;

namespace RapidERP.Application.DTOs.CurrencyDTOs;

public class CurrencyPOST : BasePOST
{ 
    public string Code { get; set; }
    public string Icon { get; set; } 
}
