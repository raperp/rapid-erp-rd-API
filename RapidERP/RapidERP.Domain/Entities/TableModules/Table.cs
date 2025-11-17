using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Domain.Entities.TableModules;

public class Table : BaseMaster
{
    public int TotalPersons { get; set; }
    public string Description { get; set; }
}
