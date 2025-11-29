using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Domain.Entities.SateModules;
public class StateAudit : BaseHistory
{
    public State State { get; set; }
    public int StateId { get; set; }
    public int? CountryId { get; set; }
    public int? MenuId { get; set; }
    public int? LanguageId { get; set; }
    public string Code { get; set; }
}
