using RapidERP.Domain.Entities.DepartmentModels;
using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Domain.Entities.DesignationModels;
public class Designation : BaseMaster
{
    public Department Department { get; set; }
    public int DepartmentId { get; set; }
    public string Description { get; set; }
}
