namespace RapidERP.Application.DTOs.Shared;

public record class BaseDTO     
{
    public string Name { get; set; }
    public int? TenantId { get; set; }
    public int? StatusTypeId { get; set; } 
    public int? DefaultLanguageId { get; set; } 
    public string Code { get; set; }
    public bool? IsDefault { get; set; }
    public bool? IsDraft { get; set; }
}