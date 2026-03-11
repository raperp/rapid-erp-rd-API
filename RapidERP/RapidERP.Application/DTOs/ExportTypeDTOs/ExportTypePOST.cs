using RapidERP.Application.DTOs.Shared;

namespace RapidERP.Application.DTOs.ExportTypeDTOs;

public record class ExportTypePOST : BaseConfigDTO
{
    //public int LanguageId { get; set; }
    public string Description { get; set; }
    //public int ActionBy { get; set; }
}
