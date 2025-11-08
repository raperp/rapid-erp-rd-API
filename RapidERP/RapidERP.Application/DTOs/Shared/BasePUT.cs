namespace RapidERP.Application.DTOs.Shared;
public class BasePUT : AuditDTO
{
    public int Id { get; set; }
    public long UpdatedBy { get; set; }
    //public DateTime UpdatedAt { get; set; }
}
