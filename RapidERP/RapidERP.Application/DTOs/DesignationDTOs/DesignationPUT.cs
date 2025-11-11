using RapidERP.Application.DTOs.Shared;

namespace RapidERP.Application.DTOs.DesignationDTOs;
public class DesignationPUT : BasePUT
{
    public int? DepartmentId { get; set; }
    public string Description { get; set; }
}
