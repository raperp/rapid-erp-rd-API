namespace RapidERP.Application.DTOs.Shared;

public record ActionDTO
{
    public DateTime? CreatedAt { get; set; }
    public DateTime? DraftedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}
