using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Domain.Entities.SolutionModels;

public class Solution : BaseMaster
{
    public string Code { get; set; }
    public string Icon { get; set; }
    public string Description { get; set; }
}
