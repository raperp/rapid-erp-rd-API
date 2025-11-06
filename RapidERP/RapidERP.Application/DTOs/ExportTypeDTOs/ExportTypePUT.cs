using RapidERP.Application.DTOs.Shared;

namespace RapidERP.Application.DTOs.ExportTypeDTOs;
public class ExportTypePUT : BasePUT
{
    public int LanguageId { get; set; }
    public string Description { get; set; }
}
