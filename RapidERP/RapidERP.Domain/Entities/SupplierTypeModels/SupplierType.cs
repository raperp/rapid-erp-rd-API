using RapidERP.Domain.Entities.CountryModels;
using RapidERP.Domain.Entities.CurrencyModels;
using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Domain.Entities.SupplierTypeModels;
public class SupplierType : BaseMaster
{
    public string VATNumber { get; set; }
    public string Website { get; set; }
    public string Phone { get; set; }
    public Currency Currency { get; set; }
    public int CurrencyId { get; set; }
    public Country Country { get; set; }
    public int CountryId { get; set; }
    public Language Language { get; set; }
    public int LanguageId { get; set; }
    public string Street { get; set; }
    public string PostCode { get; set; }
}
