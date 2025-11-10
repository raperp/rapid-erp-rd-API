using RapidERP.Application.DTOs.Shared;

namespace RapidERP.Application.DTOs.CityDTOs;
public class CityPUT : BasePUT
{
    public string Code { get; set; }
    public int CountryId { get; set; }
    public int StateId { get; set; }
}
