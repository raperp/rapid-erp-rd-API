namespace RapidERP.Application.Features.ActionTypeFeatures.GetAllQuery;

public record GetAllActionTypeResponseDTOModel
{
    public int Id { get; set; } 
    public string Language { get; set; } 
    public string Name { get; set; }
    public string Description { get; set; }
}
