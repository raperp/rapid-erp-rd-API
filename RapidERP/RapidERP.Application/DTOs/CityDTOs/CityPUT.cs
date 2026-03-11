using RapidERP.Application.DTOs.Shared;

namespace RapidERP.Application.DTOs.CityDTOs;

public record class CityPUT : BasePUT
{
    public int CountryId { get; set; }
    public int StateId { get; set; }
}
