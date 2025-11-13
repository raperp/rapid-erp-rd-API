using RapidERP.Domain.Entities.CountryModels;
using RapidERP.Domain.Entities.CurrencyModels;
using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Domain.Entities.SupplierModels;
public class Supplier : BaseMaster
{
    public Country Country { get; set; }
    public int CountryId { get; set; }
    public int? PaymentTermsId { get; set; }
    public int? DueDays { get; set; }
    public int? DepositTypeId { get; set; }
    public int? PaymentTypeId { get; set; }
    public decimal? DepositAmount { get; set; }
    public Currency Currency { get; set; }
    public int CurrencyId { get; set; }
    public decimal? ExchangeRate { get; set; }
    public decimal? LocalAmount { get; set; }
    public string ContactPersonName { get; set; }
    public string Mobile { get; set; }
    public string Email { get; set; }
    public string Website { get; set; }
}
