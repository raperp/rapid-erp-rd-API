using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Application.DTOs.CountryDTOs;

public record CountryCurrencyPOST : CurrencyDTO
{
    public int? CountryId { get; set; }
}
