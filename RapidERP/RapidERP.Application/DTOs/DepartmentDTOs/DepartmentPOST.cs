using RapidERP.Application.DTOs.Shared;

namespace RapidERP.Application.DTOs.DepartmentDTOs;
public record class DepartmentPOST : BasePOST
{
    public string Description { get; set; }
    public bool IsDefault { get; set; }
    public bool IsDraft { get; set; }
}
