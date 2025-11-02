using RapidERP.Application.DTOs.Shared;

namespace RapidERP.Application.DTOs.LanguageDTOs;
public class LanguagePUT : TrackerDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ISO2Code { get; set; }
    public string ISO3Code { get; set; }
    public string ISONumeric { get; set; }
    public string Icon { get; set; }
    public long UpdatedBy { get; set; }
}
