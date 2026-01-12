using RapidERP.Application.DTOs.Shared;

namespace RapidERP.Application.DTOs.MainModuleDTOs;

public record class MainModulePUT : TrackerDTO
{
    public int Id { get; set; }
    public int? LanguageId { get; set; }
    public string Name { get; set; }
    public string Prefix { get; set; }
    public string IconURL { get; set; }
    public int SetSerial { get; set; }
    public int ActionTypeId { get; set; }
    public int ExportTypeId { get; set; }
    public string ExportTo { get; set; }
    public string SourceURL { get; set; }
    public bool IsDraft { get; set; }
}
