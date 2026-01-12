using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.ActionTypeFeatures.GetSingleQuery;

public record GetSingleActionTypeResponseDTOModel
{
    public int Id { get; set; }
    public string Language { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}
