using RapidERP.Domain.Entities.CountryModels;
using RapidERP.Domain.Entities.MenuModuleModels;
using RapidERP.Domain.Entities.SateModules;
using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Domain.Entities.TenantModels;

public class Tenant : BaseMaster
{
    //public Country Country { get; set; }
    public int? CountryId { get; set; }
    //public State State { get; set; }
    public int? StateId { get; set; }
    public string Contact { get; set; }
    public string Phone { get; set; }
    public string Mobile { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public string Website { get; set; }
    public MenuModule MenuModule { get; set; }
    public int? MenuModuleId { get; set; }
}
