namespace RapidERP.Application.DTOs.Shared;

public record  BaseConfigDTO
{
    public string Name { get; set; } 
    public string Code { get; set; }
    public bool? IsDefault { get; set; }
    public bool? IsDraft { get; set; }
    public int? DefaultLanguageId { get; set; }
    public int? LanguageId { get; set; }
}
