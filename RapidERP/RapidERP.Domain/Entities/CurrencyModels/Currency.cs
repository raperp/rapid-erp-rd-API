using RapidERP.Domain.Entities.CountryModels;
using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Domain.Entities.CurrencyModels;

public class Currency : BaseMaster
{
    public string Code { get; set; }
    public string Icon { get; set; }
    //public ICollection<Country> Countries { get; set; }
}
