namespace RapidERP.Application.DTOs.Shared;

public class ActionDTO
{
    public int? UpdatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public int? DraftedBy { get; set; }
    public DateTime? DraftedAt { get; set; }
    public int? DeletedBy { get; set; }
    public DateTime? DeletedAt { get; set; }
}
