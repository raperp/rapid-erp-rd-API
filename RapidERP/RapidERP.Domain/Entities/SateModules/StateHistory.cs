using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Domain.Entities.SateModules;

public class StateHistory : BaseAudit
{
    public State State { get; set; }
    public int StateId { get; set; }
    public int? CountryId { get; set; }
    public string Code { get; set; }
}
