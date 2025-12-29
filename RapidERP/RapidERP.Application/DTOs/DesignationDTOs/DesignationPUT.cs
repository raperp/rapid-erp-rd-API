using RapidERP.Application.DTOs.Shared;

namespace RapidERP.Application.DTOs.DesignationDTOs;
public record class DesignationPUT : BasePUT
{
    public int? DepartmentId { get; set; }
    public string Description { get; set; }
    public bool IsDefault { get; set; }
    public bool IsDraft { get; set; }
}
