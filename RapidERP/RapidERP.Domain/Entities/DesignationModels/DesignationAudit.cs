using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Domain.Entities.DesignationModels;
public class DesignationAudit : BaseAudit
{
    public Designation Designation { get; set; }
    public int DesignationId { get; set; }
    public int? DepartmentId { get; set; }
    public string Description { get; set; }
}
