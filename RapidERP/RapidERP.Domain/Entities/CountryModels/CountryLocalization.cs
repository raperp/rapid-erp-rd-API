using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Domain.Entities.CountryModels;

public class CountryLocalization : Localization
{
    public Country Country { get; set; }
    public int? CountryId { get; set; }
}
