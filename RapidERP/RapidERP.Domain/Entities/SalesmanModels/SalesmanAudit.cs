using RapidERP.Domain.Entities.DepartmentModels;
using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Domain.Entities.SalesmanModels;
public class SalesmanAudit : BaseAudit
{
    public Salesman Salesman { get; set; }
    public int SalesmanId { get; set; }
    public string Code { get; set; }
    public decimal? Commission { get; set; }
    public string Territory { get; set; }
    public decimal? Experience { get; set; }
    public int? DepartmentId { get; set; }
    public int? ManagerId { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Description { get; set; }
}
