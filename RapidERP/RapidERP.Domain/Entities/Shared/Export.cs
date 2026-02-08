namespace RapidERP.Domain.Entities.Shared;

public class Export : Master  
{
    public int? ExportMediaId { get; set; }
    public string ExportMediaTo { get; set; }
    public string ExportMediaURL { get; set; }
}
