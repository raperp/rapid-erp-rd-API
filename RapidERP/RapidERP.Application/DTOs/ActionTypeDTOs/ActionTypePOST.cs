using RapidERP.Application.DTOs.Shared;

namespace RapidERP.Application.DTOs.ActionTypeDTOs;
public class ActionTypePOST : TrackerDTO
{
    public int Id { get; set; }
    public int LanguageId { get; set; }
    public string Name { get; set; }
    public long CreatedBy { get; set; }
    public string Description { get; set; }
}
