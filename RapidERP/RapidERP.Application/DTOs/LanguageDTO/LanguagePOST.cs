using RapidERP.Application.DTOs.Shared;

namespace RapidERP.Application.DTOs.LanguageDTO;
public class LanguagePOST : TrackerDTO
{
    public string Name { get; set; }
    public string ISO2Code { get; set; }
    public string ISO3Code { get; set; }
    public string ISONumeric { get; set; }
    public string Icon { get; set; }
    public long CreatedBy { get; set; }
}
