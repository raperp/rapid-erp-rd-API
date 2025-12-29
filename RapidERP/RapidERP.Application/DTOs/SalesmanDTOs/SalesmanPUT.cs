using RapidERP.Application.DTOs.Shared;

namespace RapidERP.Application.DTOs.SalesmanDTOs;

public record class SalesmanPUT : BasePUT
{
    public string Code { get; set; }
    public decimal? Commission { get; set; }
    public string Territory { get; set; }
    public decimal? Experience { get; set; }
    public int? DepartmentId { get; set; }
    public int? ManagerId { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Description { get; set; }
    public bool IsDefault { get; set; }
    public bool IsDraft { get; set; }
}
