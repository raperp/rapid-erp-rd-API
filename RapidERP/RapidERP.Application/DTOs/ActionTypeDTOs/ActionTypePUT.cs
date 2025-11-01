using RapidERP.Application.DTOs.Shared;

namespace RapidERP.Application.DTOs.ActionTypeDTOs;
public class ActionTypePUT : TrackerDTO
{
    public int Id { get; set; }
    public int ActionTypeAuditId { get; set; }
    public int ActionTypeTrackerId { get; set; }
    public int LanguageId { get; set; }
    public string Name { get; set; }
    public long UpdatedBy { get; set; }
    public string Description { get; set; }
}
