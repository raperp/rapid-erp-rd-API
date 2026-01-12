namespace RapidERP.Application.Features.StatusTypeFeatures.GetSingleQuery;

public record GetSingleStatusTypeResponseDTOModel 
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}
