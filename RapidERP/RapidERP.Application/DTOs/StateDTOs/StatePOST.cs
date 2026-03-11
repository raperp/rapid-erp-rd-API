using RapidERP.Application.DTOs.Shared;

namespace RapidERP.Application.DTOs.StateDTOs;

public record StatePOST : BasePOST
{
    public int? CountryId { get; set; } 
    public int? LanguageId { get; set; } 
}
