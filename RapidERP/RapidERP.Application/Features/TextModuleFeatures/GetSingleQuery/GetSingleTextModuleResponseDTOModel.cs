namespace RapidERP.Application.Features.TextModuleFeatures.GetSingleQuery;

public record GetSingleTextModuleResponseDTOModel
{
    public int Id { get; set; }
    public string MenuModule { get; set; }
    public string Language { get; set; }
    public string Name { get; set; }
}
