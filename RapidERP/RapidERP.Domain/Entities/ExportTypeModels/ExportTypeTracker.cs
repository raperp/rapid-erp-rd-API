using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Domain.Entities.ExportTypeModels;
public class ExportTypeTracker : Tracker
{
    public string ExportTo { get; set; }
}
