namespace RapidERP.Application.Features.MessageModuleFeatures.GetSingleQuery;

public record GetSingleMessageModuleResponseDTOModel
{
    public int Id { get; set; }
    public string TextModule { get; set; }
    public string Language { get; set; }
    public string Name { get; set; }
}
