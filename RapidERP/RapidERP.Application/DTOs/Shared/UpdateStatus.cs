namespace RapidERP.Application.DTOs.Shared;

public record UpdateStatus
{
    public int Id { get; set; }
    public bool IsActive { get; set; }
    public bool IsDelete { get; set; }
}
