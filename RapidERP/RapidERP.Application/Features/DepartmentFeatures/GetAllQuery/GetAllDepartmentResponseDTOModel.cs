namespace RapidERP.Application.Features.DepartmentFeatures.GetAllQuery;

public record GetAllDepartmentResponseDTOModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string MenuModule { get; set; }
    public string Tanent { get; set; }
    public string Language { get; set; }
    public string Status { get; set; }
}
