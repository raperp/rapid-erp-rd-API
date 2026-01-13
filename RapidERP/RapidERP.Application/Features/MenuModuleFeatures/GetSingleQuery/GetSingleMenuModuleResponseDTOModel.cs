namespace RapidERP.Application.Features.MenuModuleFeatures.GetSingleQuery;

public record GetSingleMenuModuleResponseDTOModel
{
    public int Id { get; set; }
    public string Submodule { get; set; }
    public string Language { get; set; }
    public string Name { get; set; }
    public string IconURL { get; set; }
    public int SetSerial { get; set; }
}
