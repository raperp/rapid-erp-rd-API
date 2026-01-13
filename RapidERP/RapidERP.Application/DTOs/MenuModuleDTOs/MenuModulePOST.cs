using RapidERP.Application.DTOs.Shared;

namespace RapidERP.Application.DTOs.MenuModuleDTOs;

public record class MenuModulePOST : TrackerDTO
{
    public int? SubmoduleId { get; set; }
    public int? LanguageId { get; set; }
    public string Name { get; set; }
    public string IconURL { get; set; }
    public int SetSerial { get; set; }
    public bool IsDraft { get; set; }
    public int ActionTypeId { get; set; }
    public int ExportTypeId { get; set; }
    public string ExportTo { get; set; }
    public string SourceURL { get; set; }
}
