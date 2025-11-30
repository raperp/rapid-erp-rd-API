using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Domain.Entities.TenantModels;

public class TenantLanguage : Master
{
    public Tenant Tenant { get; set; }
    public int? TenantId { get; set; }
    public int InterfaceLanguageId { get; set; }
    public int DataLanguageId { get; set; }
    public int DefaultLanguageId { get; set; }
}
