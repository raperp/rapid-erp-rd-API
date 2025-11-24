using RapidERP.Domain.Entities.MenuModules;
using RapidERP.Domain.Entities.StatusTypeModels;

namespace RapidERP.Domain.Entities.Shared;

public class BaseMaster : Master
{
    public Menu Menu { get; set; }
    public int MenuId { get; set; }
    public StatusType StatusType { get; set; }
    public int StatusTypeId { get; set; }
    public int? CreatedBy { get; set; }
    public DateTime? CreatedAt { get; set; }
    public int? DraftedBy { get; set; }
    public DateTime? DraftedAt { get; set; }
    public int? UpdatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public int? SoftDeletedBy { get; set; }
    public DateTime? SoftDeletedAt { get; set; }
    public int? RestoredBy { get; set; }
    public DateTime? RestoredAt { get; set; }
}
