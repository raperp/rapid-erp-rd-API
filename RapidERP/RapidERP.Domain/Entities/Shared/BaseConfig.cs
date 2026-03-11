using RapidERP.Domain.Entities.LanguageModels;

namespace RapidERP.Domain.Entities.Shared;

public class BaseConfig : Master
{
    public Language Language { get; set; }
    public int? LanguageId { get; set; }
    public string Code { get; set; } 
    public bool? IsDefault { get; set; }
    public bool? IsDraft { get; set; }
    public int? DefaultLanguageId { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? DraftedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}
