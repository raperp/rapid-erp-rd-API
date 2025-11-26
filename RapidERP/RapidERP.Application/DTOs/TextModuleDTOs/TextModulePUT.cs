using RapidERP.Application.DTOs.Shared;

namespace RapidERP.Application.DTOs.TextModuleDTOs;

public class TextModulePUT : TrackerDTO
{
    public int Id { get; set; }
    public int MenuModuleId { get; set; }
    public int LanguageId { get; set; }
    public string Name { get; set; }
    public bool IsDraft { get; set; }
    public int ActionTypeId { get; set; }
    public int ExportTypeId { get; set; }
    public string ExportTo { get; set; }
    public string SourceURL { get; set; }
}
