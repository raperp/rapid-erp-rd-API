using RapidERP.Application.DTOs.Shared;

namespace RapidERP.Application.DTOs.RiderDTOs;

public record class RiderPUT : BasePUT
{
    public string Email { get; set; }
    public string MobileNumber { get; set; }
    public string Description { get; set; }
    public int CountryId { get; set; }
    public int StateId { get; set; }
    public int CityId { get; set; }
    public int AreaId { get; set; }
}
