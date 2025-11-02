namespace RapidERP.Application.DTOs.Shared;
public class ExportDTO
{
    public int Id { get; set; }
    public int ExportTypeId { get; set; }
    public string ExportTo { get; set; }
    public string SourceURL { get; set; }
}
