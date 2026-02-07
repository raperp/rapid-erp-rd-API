namespace RapidERP.Application.DTOs.Shared;

public record LocalizationDTO
{
    
    public int? LanguageId { get; set; }
    public string Name { get; set; }
}
