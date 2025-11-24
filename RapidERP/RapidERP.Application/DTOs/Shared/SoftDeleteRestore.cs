namespace RapidERP.Application.DTOs.Shared;

public class SoftDeleteRestore 
{
    public int Id { get; set; }
    public int ActionBy { get; set; }
    public bool IsSoftDelete { get; set; }
    public int StatusTypeId { get; set; }
}
