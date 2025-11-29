using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Domain.Entities.CityModels;
public class CityAudit : BaseHistory
{
    public City City { get; set; }
    public int CityId { get; set; }
    public string Code { get; set; }
    public int? CountryId { get; set; }
    public int? StateId { get; set; }
}
