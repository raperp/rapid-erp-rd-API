using RapidERP.Application.DTOs.Shared;

namespace RapidERP.Application.DTOs.AreaDTOs;
public record class AreaPUT : BasePUT
{
    public string Code { get; set; }
    public int CountryId { get; set; }
    public int StateId { get; set; }
    public int CityId { get; set; }
    public bool IsDefault { get; set; }
    public bool IsDraft { get; set; }
}
