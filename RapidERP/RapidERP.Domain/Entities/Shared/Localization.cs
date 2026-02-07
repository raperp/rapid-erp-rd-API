using RapidERP.Domain.Entities.LanguageModels;

namespace RapidERP.Domain.Entities.Shared;

public class Localization : Master
{
    public Language Language { get; set; }
    public int? LanguageId { get; set; }
}
