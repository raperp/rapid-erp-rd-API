using RapidERP.Application.DTOs.Shared;

namespace RapidERP.Application.DTOs.SupplierTypeDTOs;
public record class SupplierTypePOST : BasePOST
{
    public string VATNumber { get; set; }
    public string Website { get; set; }
    public string Phone { get; set; }
    public int CurrencyId { get; set; }
    public int CountryId { get; set; }
    public int LanguageId { get; set; }
    public string Street { get; set; }
    public string PostCode { get; set; }
}
