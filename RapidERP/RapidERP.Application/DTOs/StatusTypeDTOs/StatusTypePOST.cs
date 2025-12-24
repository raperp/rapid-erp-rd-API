using RapidERP.Application.DTOs.Shared;

namespace RapidERP.Application.DTOs.StatusTypeDTOs;

public class StatusTypePOST : TrackerDTO
{
    public int LanguageId { get; set; }
    public int ExportTypeId { get; set; }
    public int ActionTypeId { get; set; }
    public string ExportTo { get; set; }
    public string SourceURL { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}
