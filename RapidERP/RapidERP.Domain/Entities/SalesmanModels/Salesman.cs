using RapidERP.Domain.Entities.DepartmentModels;
using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Domain.Entities.SalesmanModels;
public class Salesman : BaseMaster
{
    public string Code { get; set; }
    public decimal? Commission { get; set; }
    public string Territory { get; set; }
    public decimal? Experience { get; set; }
    public Department Department { get; set; }
    public int DepartmentId { get; set; }
    public int? ManagerId { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Description { get; set; }
}
