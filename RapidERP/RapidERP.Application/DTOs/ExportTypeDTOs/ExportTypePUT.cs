using RapidERP.Application.DTOs.Shared;

namespace RapidERP.Application.DTOs.ExportTypeDTOs;
public class ExportTypePUT : TrackerDTO
{
    public int Id { get; set; }
    public int ExportTypeAuditId { get; set; }
    public int ExportTypeTrackerId { get; set; }
    public int LanguageId { get; set; }
    public string Name { get; set; }
    public long UpdatedBy { get; set; }
    public string Description { get; set; }
}
