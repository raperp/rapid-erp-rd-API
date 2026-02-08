using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Domain.Entities.CountryModels;

public class CountryExport : Export
{
    public Country Country { get; set; }
    public int? CountryId { get; set; } 
}
