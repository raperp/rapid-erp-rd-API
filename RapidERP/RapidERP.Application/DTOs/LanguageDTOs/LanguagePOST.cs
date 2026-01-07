using RapidERP.Application.DTOs.Shared;

namespace RapidERP.Application.DTOs.LanguageDTOs;

public record LanguagePOST : BasePOST 
{
    public string ISONumeric { get; set; } 
    public string ISO2Code { get; set; }
    public string ISO3Code { get; set; }
    public string IconURL { get; set; } 
    public bool IsDraft { get; set; } 
}
