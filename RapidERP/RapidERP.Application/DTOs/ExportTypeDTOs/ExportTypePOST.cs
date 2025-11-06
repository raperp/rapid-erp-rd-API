using RapidERP.Application.DTOs.Shared;

namespace RapidERP.Application.DTOs.ExportTypeDTOs;
public class ExportTypePOST : BasePOST
{
    public int LanguageId { get; set; }
    public string Description { get; set; }
    public string FlagURL { get; set; }
}
