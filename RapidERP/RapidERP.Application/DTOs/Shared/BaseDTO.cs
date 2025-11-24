namespace RapidERP.Application.DTOs.Shared;

public class BaseDTO : AuditDTO
{
    public string Name { get; set; }
    public int MenuId { get; set; }
    public int StatusTypeId { get; set; }
}