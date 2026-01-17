namespace RapidERP.Application.Features.CurrencyFeatures.GetSingleQuery;

public record GetSingleCurrencyResponseDTOModel
{
    public int Id { get; set; }
    public string Tenant { get; set; }
    public string MenuModule { get; set; }
    public string Language { get; set; }
    public string Status { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string Icon { get; set; }
    public bool IsDefault { get; set; }
    public bool IsDraft { get; set; }
}
