using RapidERP.Application.DTOs.Shared;

namespace RapidERP.Application.DTOs.ExportTypeDTOs;
public class ExportTypePOST : TrackerDTO
{
    public int LanguageId { get; set; }
    public string Name { get; set; }
    public long CreatedBy { get; set; }
    public string Description { get; set; }
}
