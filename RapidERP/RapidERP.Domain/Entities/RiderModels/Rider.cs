using RapidERP.Domain.Entities.AreaModules;
using RapidERP.Domain.Entities.CityModels;
using RapidERP.Domain.Entities.CountryModels;
using RapidERP.Domain.Entities.SateModules;
using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Domain.Entities.RiderModels;
public class Rider : BaseMaster
{
    public string Email { get; set; }
    public string MobileNumber { get; set; }
    public string Description { get; set; }
    public Country Country { get; set; }
    public int CountryId { get; set; }
    public State State { get; set; }
    public int StateId { get; set; }
    public City City { get; set; }
    public int CityId { get; set; }
    public Area Area { get; set; }
    public int AreaId { get; set; }
}
