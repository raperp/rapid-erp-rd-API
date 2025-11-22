using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Domain.Entities.LanguageModels;
public class Language : BaseMaster
{
    public string ISONumeric { get; set; }
    public string ISO2Code { get; set; }
    public string ISO3Code { get; set; }
    public string Icon { get; set; }
}
