using RapidERP.Application.DTOs.Shared;

namespace RapidERP.Application.DTOs.CountryDTOs;

public record CountryLocalizationPUT : LocalizationDTO
{
    public int Id { get; set; }
    public int? CountryId { get; set; }
}
