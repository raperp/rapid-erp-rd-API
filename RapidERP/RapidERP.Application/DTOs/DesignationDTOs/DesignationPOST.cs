using RapidERP.Application.DTOs.Shared;

namespace RapidERP.Application.DTOs.DesignationDTOs;
public class DesignationPOST : BasePOST
{
    public int DepartmentId { get; set; }
    public string Description { get; set; }
}
