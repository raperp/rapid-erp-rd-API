using RapidERP.Application.DTOs.Shared;

namespace RapidERP.Application.DTOs.CountryDTOs;

public record CountryPOST : BasePOST
{
    public string ISONumeric { get; set; } 
    public string ISO2Code { get; set; }
    public string ISO3Code { get; set; }
    public string FlagURL { get; set; }
    public bool IsDefault { get; set; }
    public bool IsDraft { get; set; }
    public int CurrencyId { get; set; }
    public int? DefaultLanguageId { get; set; }
    //public int? ActionTypeId { get; set; } 
}
