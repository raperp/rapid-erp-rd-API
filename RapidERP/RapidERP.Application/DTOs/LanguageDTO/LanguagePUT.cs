using RapidERP.Application.DTOs.Shared;

namespace RapidERP.Application.DTOs.LanguageDTO;
public class LanguagePUT : TrackerDTO
{
    public int Id { get; set; }
    public int LanguageAuditId { get; set; }
    public int LanguageTrackerId { get; set; }
    public string Name { get; set; }
    public string ISO2Code { get; set; }
    public string ISO3Code { get; set; }
    public string ISONumeric { get; set; }
    public string Icon { get; set; }
    public long? UpdatedBy { get; set; }
}
