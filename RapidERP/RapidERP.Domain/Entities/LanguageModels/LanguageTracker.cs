using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Domain.Entities.LanguageModels;
public class LanguageTracker : Base 
{
    public Language Language { get; set; }
    public int LanguageId { get; set; }
}
