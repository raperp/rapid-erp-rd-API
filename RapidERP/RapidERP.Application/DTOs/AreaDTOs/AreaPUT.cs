using RapidERP.Application.DTOs.Shared;

namespace RapidERP.Application.DTOs.AreaDTOs;

public record class AreaPUT : BasePUT
{
    public int CountryId { get; set; }
    public int StateId { get; set; }
    public int CityId { get; set; }
}
