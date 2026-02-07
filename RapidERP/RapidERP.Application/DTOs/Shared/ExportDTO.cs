namespace RapidERP.Application.DTOs.Shared;

public record ExportDTO
{
    public int ExportMediaId { get; set; }
    public string ExportMediaTo { get; set; }
    public string ExportMediaURL { get; set; }
    public int ActionTypeId { get; set; }
    public int ActionBy { get; set; }
    public DateTime ActionAt { get; set; }
}
