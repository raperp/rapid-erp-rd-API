using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Domain.Entities.TableModules;

public class TableAudit : BaseHistory
{
    public Table Table { get; set; }
    public int TableId { get; set; }
    public int TotalPersons { get; set; }
    public string Description { get; set; }
}
