using RapidERP.Application.DTOs.Shared;

namespace RapidERP.Application.DTOs.CountryDTOs;
public class CountryPOST : BasePOST
{
    public int? TenantId { get; set; }
    public int MenuId { get; set; }
    public int LanguageId { get; set; }
    public string ISONumeric { get; set; }
    public string DialCode { get; set; }
    public string ISO2Code { get; set; }
    public string ISO3Code { get; set; }
    public string FlagURL { get; set; }
}
