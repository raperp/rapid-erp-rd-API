using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Entities.StatusTypeModels;
using RapidERP.Domain.Entities.TenantModels;

namespace RapidERP.Domain.Entities.Shared;

public class BaseMaster : Master
{
    public Tenant Tenant { get; set; }
    public int? TenantId { get; set; }
    public StatusType StatusType { get; set; }
    public int? StatusTypeId { get; set; } 
    public int? DefaultLanguageId { get; set; }
    public string Code { get; set; }
    public bool? IsDefault { get; set; }
    public bool? IsDraft { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? DraftedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}