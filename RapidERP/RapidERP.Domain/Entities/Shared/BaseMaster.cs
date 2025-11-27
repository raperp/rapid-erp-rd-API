using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Entities.MenuModuleModels;
using RapidERP.Domain.Entities.StatusTypeModels;
using RapidERP.Domain.Entities.TenantModels;

namespace RapidERP.Domain.Entities.Shared;

public class BaseMaster : Master
{
    public MenuModule MenuModule { get; set; }
    public int? MenuModuleId { get; set; }
    public Tenant Tenant { get; set; }
    public int? TenantId { get; set; }
    public StatusType StatusType { get; set; }
    public int? StatusTypeId { get; set; }
    public Language Language { get; set; }
    public int? LanguageId { get; set; }
    public bool IsDefault { get; set; }
    public bool IsDraft { get; set; }
    //public int? CreatedBy { get; set; }
    //public DateTime? CreatedAt { get; set; }
    //public int? DraftedBy { get; set; }
    //public DateTime? DraftedAt { get; set; }
    //public int? UpdatedBy { get; set; }
    //public DateTime? UpdatedAt { get; set; }
    //public int? DeletedBy { get; set; }
    //public DateTime? DeletedAt { get; set; }
}
