using RapidERP.Application.DTOs.Shared;

namespace RapidERP.Application.DTOs.CountryDTOs;

public record CountryLocalizationPOST : LocalizationDTO
{
    public int CountryId { get; set; } 
}
