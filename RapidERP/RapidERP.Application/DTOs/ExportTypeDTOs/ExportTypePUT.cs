using RapidERP.Application.DTOs.Shared;

namespace RapidERP.Application.DTOs.ExportTypeDTOs;

public record ExportTypePUT : BaseConfigDTO
{
    public int Id { get; set; }
    public string Description { get; set; } 
    //public bool IsDraft { get; set; }
    //public int ActionBy { get; set; }
}
