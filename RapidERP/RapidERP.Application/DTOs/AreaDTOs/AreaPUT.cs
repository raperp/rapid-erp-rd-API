using RapidERP.Application.DTOs.Shared;

namespace RapidERP.Application.DTOs.AreaDTOs;
public class AreaPUT : BasePUT
{
    public string Code { get; set; }
    public int CountryId { get; set; }
    public int StateId { get; set; }
    public int CityId { get; set; }
}
