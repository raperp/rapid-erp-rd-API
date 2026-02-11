namespace RapidERP.Application.DTOs.CountryDTOs;

public record CountryCurrencyPUT : CurrencyDTO
{
    public int Id { get; set; }
    public int? CountryId { get; set; }
}
