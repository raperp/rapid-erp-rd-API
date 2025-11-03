using RapidERP.Domain.Entities.ExportTypeModels;

namespace RapidERP.Domain.Entities.Shared;
public class Base : Tracker
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ExportTo { get; set; }
    public string SourceURL { get; set; }
    public ExportType ExportType { get; set; }
    public int ExportTypeId { get; set; }  
    public int ActionTypeId { get; set; } //FK
    public int StatusTypeId { get; set; } //FK
    public bool IsDefault { get; set; }
}
