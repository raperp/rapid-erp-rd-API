using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Domain.Entities.SolutionModels;

public class SolutionTemplate : Master
{
    public string Code { get; set; }
    public string Icon { get; set; }
    public string Description { get; set; }
}
