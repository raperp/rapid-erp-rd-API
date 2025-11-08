using RapidERP.Domain.Entities.ActionTypeModels;
using RapidERP.Domain.Entities.ExportTypeModels;
using RapidERP.Domain.Entities.StatusTypeModels;

namespace RapidERP.Domain.Entities.Shared;
public class BaseAudit : Tracker
{
    //public int Id { get; set; }
    //public string Name { get; set; }
    public string ExportTo { get; set; }
    public string SourceURL { get; set; }
    //public ExportType ExportType { get; set; }
    public int? ExportTypeId { get; set; }  
    public ActionType ActionType { get; set; }
    public int ActionTypeId { get; set; }
    public StatusType StatusType { get; set; }
    public int StatusTypeId { get; set; }  
    public bool IsDefault { get; set; }
}
