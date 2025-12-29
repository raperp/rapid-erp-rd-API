using RapidERP.Application.DTOs.Shared;

namespace RapidERP.Application.DTOs.CityDTOs;
public record class CityPUT : BasePUT
{
    public string Code { get; set; }
    public int CountryId { get; set; }
    public int StateId { get; set; }
    public bool IsDefault { get; set; }
    public bool IsDraft { get; set; }
}
