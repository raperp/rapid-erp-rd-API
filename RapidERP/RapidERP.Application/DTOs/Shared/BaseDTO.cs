namespace RapidERP.Application.DTOs.Shared;

public record class BaseDTO     
{
    public string Name { get; set; }
    public int? TenantId { get; set; }
    public int? StatusTypeId { get; set; }
    //public int? LanguageId { get; set; }
    public int? DefaultLanguageId { get; set; }
    public int ActionBy { get; set; }
    public string Code { get; set; }
    //public bool? IsActive { get; set; }
    //public bool? IsDeleted { get; set; }
    //public int? ActionTypeId { get; set; }
}