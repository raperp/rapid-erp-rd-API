namespace RapidERP.Application.Features.TenantFeatures.GetAllQuery;

public record GetAllTenantResponseDTOModel
{
    public int Id { get; set; }
    public string MenuModule { get; set; }
    public string Country { get; set; }
    public string State { get; set; }
    public string Status { get; set; }
    public string Language { get; set; }
    public string Name { get; set; }
    public string Contact { get; set; }
    public string Phone { get; set; }
    public string Mobile { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public string Website { get; set; }
}
