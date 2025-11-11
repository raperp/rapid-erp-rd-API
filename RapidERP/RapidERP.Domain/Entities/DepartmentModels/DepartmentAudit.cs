using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Domain.Entities.DepartmentModels;
public class DepartmentAudit : BaseAudit
{
    public Department Department { get; set; }
    public int DepartmentId { get; set; }
    public string Description { get; set; }
}
