using RapidERP.Application.DTOs.Shared;

namespace RapidERP.Application.DTOs.LanguageDTOs.LanguageMaster;

public record LanguagePUT : BaseConfigDTO
{
    public int Id { get; set; }
    public string ISONumeric { get; set; }
    public string ISO2Code { get; set; }
    public string ISO3Code { get; set; }
    public string IconURL { get; set; }
}

