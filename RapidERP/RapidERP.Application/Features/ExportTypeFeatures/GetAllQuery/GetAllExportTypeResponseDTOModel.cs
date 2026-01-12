namespace RapidERP.Application.Features.ExportTypeFeatures.GetAllQuery;

public record GetAllExportTypeResponseDTOModel
{
    public int Id { get; set; }
    public string Language { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}
