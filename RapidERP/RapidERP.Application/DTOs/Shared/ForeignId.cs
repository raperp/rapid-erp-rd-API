using RapidERP.Domain.Entities.CountryModels;

namespace RapidERP.Application.DTOs.Shared;

public class ForeignId
{
    public Country Country { get; set; }
    public int CountryId { get; set; }
}
