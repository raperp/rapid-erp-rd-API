using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Domain.Entities.StatusTypeModels;

public class StatusTypeHistory : BaseHistory
{
    public StatusType StatusType { get; set; }
    public int? StatusTypeId { get; set; }
    public string Description { get; set; }
}
