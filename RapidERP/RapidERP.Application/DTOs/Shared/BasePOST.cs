namespace RapidERP.Application.DTOs.Shared;
public class BasePOST : AuditDTO
{
    public long CreatedBy { get; set; }
    public DateTime CreatedAt { get; set; }
}
