using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Domain.Entities.RiderModels;
public class RiderAudit : BaseAudit
{
    public Rider Rider { get; set; }
    public int RiderId { get; set; }
    public string Email { get; set; }
    public string MobileNumber { get; set; }
    public string Description { get; set; }
    public int? CountryId { get; set; }
    public int? StateId { get; set; }
    public int? CityId { get; set; }
    public int? AreaId { get; set; }
}
