using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Domain.Entities.SolutionModels;

public class SolutionHistory : BaseAudit
{
    public Solution Solution { get; set; }
    public int? SolutionId { get; set; }
    public string Code { get; set; }
    public string Icon { get; set; }
    public string Description { get; set; }
}
