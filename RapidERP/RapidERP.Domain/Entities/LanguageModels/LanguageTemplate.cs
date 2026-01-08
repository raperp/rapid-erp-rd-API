using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Domain.Entities.LanguageModels;

public class LanguageTemplate : Master
{
    public string ISONumeric { get; set; }
    public string ISO2Code { get; set; }
    public string ISO3Code { get; set; }
    public string IconURL { get; set; }
}
