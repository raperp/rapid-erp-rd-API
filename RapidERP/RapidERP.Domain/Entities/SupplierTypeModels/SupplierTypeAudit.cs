using RapidERP.Domain.Entities.CountryModels;
using RapidERP.Domain.Entities.CurrencyModels;
using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Domain.Entities.SupplierTypeModels;
public class SupplierTypeAudit : BaseAudit
{
    public SupplierType SupplierType { get; set; }
    public int SupplierTypeId { get; set; }
    public string VATNumber { get; set; }
    public string Website { get; set; }
    public string Phone { get; set; }
    public int? CurrencyId { get; set; }
    public int? CountryId { get; set; }
    public int? LanguageId { get; set; }
    public string Street { get; set; }
    public string PostCode { get; set; }
}
