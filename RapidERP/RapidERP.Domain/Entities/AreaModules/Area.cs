using RapidERP.Domain.Entities.CityModels;
using RapidERP.Domain.Entities.CountryModels;
using RapidERP.Domain.Entities.SateModules;
using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Domain.Entities.AreaModules;
public class Area : BaseMaster
{
    public string Code { get; set; }
    public Country Country { get; set; }
    public int CountryId { get; set; }
    public State State { get; set; }
    public int StateId { get; set; }
    public City City { get; set; }
    public int CityId { get; set; }
}
