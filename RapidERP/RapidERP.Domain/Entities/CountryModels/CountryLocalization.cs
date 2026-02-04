using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Domain.Entities.CountryModels;

public class CountryLocalization : Master
{
    public Country Country { get; set; }
    public int? CountryId { get; set; }
    public Language Language { get; set; }
    public int? LanguageId { get; set; }
}
