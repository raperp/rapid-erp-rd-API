namespace RapidERP.Application.Features.KitchenFeatures.GetAllQuery;

public record GetKitchenResponseDTOModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int? PrinterId { get; set; }
    public string Status { get; set; }
}
