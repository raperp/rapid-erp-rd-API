using RapidERP.Application.DTOs.Shared;

namespace RapidERP.Application.DTOs.TenantDTOs;

public class TenantPUT : BasePUT
{
    public string Contact { get; set; }
    public string Phone { get; set; }
    public string Mobile { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public string Website { get; set; }
    public int? CountryId { get; set; }
    public int? StateId { get; set; }
}
