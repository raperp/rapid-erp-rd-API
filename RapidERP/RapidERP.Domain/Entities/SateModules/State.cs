using RapidERP.Domain.Entities.CountryModels;
using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Domain.Entities.SateModules;

public class State : BaseMaster
{
    public Country Country { get; set; }
    public int? CountryId { get; set; } 
    //public ICollection<Tenant> Tenants { get; set; }
}
