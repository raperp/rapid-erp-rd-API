namespace RapidERP.Application.Features.SolutionFeatures.GetSingleQuery;

public record GetSingleSolutionResponseDTOModel
{
    public int Id { get; set; }
    public string Tenant { get; set; }
    public string MenuModule { get; set; }
    public string Language { get; set; }
    public string Status { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string Icon { get; set; }
    public string Description { get; set; }
}
