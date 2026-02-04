namespace RapidERP.Application.DTOs.CountryDTOs;

public class CountryLocalizationPUT
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? CountryId { get; set; }
    public int? LanguageId { get; set; }
}
