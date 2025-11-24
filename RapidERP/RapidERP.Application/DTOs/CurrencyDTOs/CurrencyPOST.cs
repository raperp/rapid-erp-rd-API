using RapidERP.Application.DTOs.Shared;

namespace RapidERP.Application.DTOs.CurrencyDTOs;
public class CurrencyPOST : BasePOST
{
    public int? MenuId { get; set; }
    public int LanguageId { get; set; }
    public string Code { get; set; }
    public string Icon { get; set; }
    public bool IsDefault { get; set; }
}
