using RapidERP.Domain.Entities.SateModules;
using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Domain.Entities.CountryModels;

public class Country : BaseMaster
{
    //public Currency Currency { get; set; }
    //public int? CurrencyId { get; set; }
    //public Language Language { get; set; }
    public int? DefaultLanguageId { get; set; }
    public int? DefaultCurrencyId { get; set; }
    public string ISONumeric { get; set; }
    //public string DialingCode { get; set; }
    public string ISO2Code { get; set; }
    public string ISO3Code { get; set; }
    public string FlagURL { get; set; }
    public ICollection<State> States { get; set; }
}
