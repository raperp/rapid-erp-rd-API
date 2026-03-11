using RapidERP.Application.DTOs.Shared;

namespace RapidERP.Application.DTOs.StateDTOs;

public record class StatePUT : BasePUT
{
    public int? CountryId { get; set; } 
    public int? LanguageId { get; set; } 
}
