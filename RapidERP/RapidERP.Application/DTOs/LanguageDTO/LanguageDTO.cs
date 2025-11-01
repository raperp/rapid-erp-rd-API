using RapidERP.Domain.Entities.LanguageModels;

namespace RapidERP.Application.DTOs.LanguageDTO;
public class LanguageDTO
{
    public List<Language> Languages { get; set; }
    public object TotalCounts { get; set; }
}
