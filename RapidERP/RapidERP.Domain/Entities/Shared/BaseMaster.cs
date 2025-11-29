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
/*
1. Delete All AT, BY fields from BaseMaster calss as they are already present in Master class.
2. Delete service calss data mapping for these fields.
3. Delete ActionDTO calss and mapping for these fields.
4. Rename all Audit classes to History classes.
5. Update DbContext to use History classes instead of Audit classes.
6. Update all references in the codebase from Audit to History.
7. Solve foreign key cycle issues if any as per shown in screenshare.






*/