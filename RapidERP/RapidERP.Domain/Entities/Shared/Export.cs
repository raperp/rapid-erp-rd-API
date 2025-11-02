using RapidERP.Domain.Entities.ExportTypeModels;

namespace RapidERP.Domain.Entities.Shared;
public class Export
{
    public int Id { get; set; }
    public ExportType ExportType { get; set; }
    public int ExportTypeId { get; set; }
    public string ExportTo { get; set; }
    public string SourceURL { get; set; }
}
