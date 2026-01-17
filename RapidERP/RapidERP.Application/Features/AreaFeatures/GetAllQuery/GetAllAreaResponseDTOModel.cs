namespace RapidERP.Application.Features.AreaFeatures.GetAllQuery;

public record GetAllAreaResponseDTOModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public string Tanent { get; set; }
    public string Language { get; set; }
    public string MenuModule { get; set; }
    public string Country { get; set; }
    public string State { get; set; }
    public string Status { get; set; }
    public string City { get; set; }
}
