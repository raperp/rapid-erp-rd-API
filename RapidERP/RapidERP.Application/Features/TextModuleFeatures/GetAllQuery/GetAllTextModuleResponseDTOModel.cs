namespace RapidERP.Application.Features.TextModuleFeatures.GetAllQuery;

public record GetAllTextModuleResponseDTOModel
{
    public int Id { get; set; }
    public string MenuModule { get; set; }
    public string Language { get; set; }
    public string Name { get; set; }
}
