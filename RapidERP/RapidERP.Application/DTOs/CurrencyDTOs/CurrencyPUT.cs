using RapidERP.Application.DTOs.Shared;

namespace RapidERP.Application.DTOs.CurrencyDTOs;
public class CurrencyPUT : BasePUT
{
    public int? MenuId { get; set; }
    public int LanguageId { get; set; }
    public string Code { get; set; }
    public string Icon { get; set; }
}
