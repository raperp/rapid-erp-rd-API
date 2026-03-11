using RapidERP.Application.DTOs.Shared;

namespace RapidERP.Application.DTOs.StatusTypeDTOs;

public record StatusTypePUT : BaseConfigDTO
{
    public int Id { get; set; }
    public string Description { get; set; }
}
