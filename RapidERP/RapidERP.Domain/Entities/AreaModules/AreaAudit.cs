using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Domain.Entities.AreaModules;
public class AreaAudit : BaseHistory
{
    public Area Area { get; set; }
    public int AreaId { get; set; }
    public string Code { get; set; }
    public int? CountryId { get; set; }
    public int? StateId { get; set; }
    public int? CityId { get; set; }
}
