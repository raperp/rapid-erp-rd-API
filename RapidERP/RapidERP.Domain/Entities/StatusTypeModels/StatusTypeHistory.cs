using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Domain.Entities.StatusTypeModels;

public class StatusTypeHistory : BaseAudit
{
    public StatusType StatusType { get; set; }
    public int? StatusTypeId { get; set; }
    public string Description { get; set; }
}
