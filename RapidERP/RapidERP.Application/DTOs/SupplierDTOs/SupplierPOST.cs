using RapidERP.Application.DTOs.Shared;

namespace RapidERP.Application.DTOs.SupplierDTOs;
public class SupplierPOST : BasePOST
{
    public int CountryId { get; set; }
    public int PaymentTermsId { get; set; }
    public int DueDays { get; set; }
    public int DepositTypeId { get; set; }
    public int PaymentTypeId { get; set; }
    public decimal DepositAmount { get; set; }
    public int CurrencyId { get; set; }
    public decimal ExchangeRate { get; set; }
    public decimal LocalAmount { get; set; }
    public string ContactPersonName { get; set; }
    public string Mobile { get; set; }
    public string Email { get; set; }
    public string Website { get; set; }
}
