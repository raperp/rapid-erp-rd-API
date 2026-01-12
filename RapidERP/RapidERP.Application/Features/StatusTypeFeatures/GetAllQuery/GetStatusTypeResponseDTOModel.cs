namespace RapidERP.Application.Features.StatusTypeFeatures.GetAllQuery;

public record GetStatusTypeResponseDTOModel
{
    public int Id { get; set; }
    public string Language { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}
