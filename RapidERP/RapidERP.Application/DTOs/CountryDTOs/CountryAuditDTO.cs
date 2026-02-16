using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Application.DTOs.CountryDTOs;

public class CountryAuditDTO : BaseAudit
{
    public int CountryId { get; set; }
    public string ISONumeric { get; set; }
    public string ISO2Code { get; set; }
    public string ISO3Code { get; set; }
    public string FlagURL { get; set; }
    public int CurrencyId { get; set; }
    public int? DefaultCurrencyId { get; set; }
}
