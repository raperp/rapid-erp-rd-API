using RapidERP.Application.DTOs.Shared;

namespace RapidERP.Application.DTOs.ActionTypeDTOs;

public record class ActionTypePOST : TrackerDTO
{
    public int LanguageId { get; set; }
    public int ExportTypeId { get; set; }
    public string ExportTo { get; set; }
    public string SourceURL { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}
