namespace RapidERP.Application.Features.SubModuleFeatures.GetSingleQuery;

public record GetSingleSubModuleResponseDTOModel
{
    public int Id { get; set; }
    public string MainModule { get; set; }
    public string Language { get; set; }
    public string Name { get; set; }
    public string IconURL { get; set; }
    public int SetSerial { get; set; }
}
