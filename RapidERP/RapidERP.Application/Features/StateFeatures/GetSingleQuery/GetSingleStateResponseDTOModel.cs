namespace RapidERP.Application.Features.StateFeatures.GetSingleQuery;

public record GetSingleStateResponseDTOModel
{
    public int Id { get; set; }
    public string Menu { get; set; }
    public string Country { get; set; }
    public string Status { get; set; }
    public string Language { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public bool IsDefault { get; set; }
    public bool IsDraft { get; set; }
}
