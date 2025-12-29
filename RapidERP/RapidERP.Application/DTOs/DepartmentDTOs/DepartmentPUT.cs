using RapidERP.Application.DTOs.Shared;

namespace RapidERP.Application.DTOs.DepartmentDTOs;
public record class DepartmentPUT : BasePUT
{
    public string Description { get; set; }
    public bool IsDefault { get; set; }
    public bool IsDraft { get; set; }
}
