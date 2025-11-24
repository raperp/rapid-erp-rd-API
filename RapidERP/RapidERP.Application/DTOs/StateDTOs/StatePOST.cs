using RapidERP.Application.DTOs.Shared;

namespace RapidERP.Application.DTOs.StateDTOs;

public class StatePOST : BasePOST
{
    public int CountryId { get; set; }
    public int? MenuId { get; set; }
    public int LanguageId { get; set; }
    public string Code { get; set; }
    public bool IsDefault { get; set; }
}
