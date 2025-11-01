using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Domain.Entities.LanguageModels;

public class Language  
{
    public int Id { get; set; }
    public string ISO2Code { get; set; }
    public string ISO3Code { get; set; }
    public string ISONumeric { get; set; }
    public string Icon { get; set; }
    public string Name { get; set; }
    public long CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public long? UpdatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
