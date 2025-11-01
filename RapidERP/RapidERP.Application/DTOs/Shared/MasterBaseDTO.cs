namespace RapidERP.Application.DTOs.Shared;
public class MasterBaseDTO
{
    public int Id { get; set; }
    public int LanguageId { get; set; }
    public string Name { get; set; }
    public long CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
    public long? UpdatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
