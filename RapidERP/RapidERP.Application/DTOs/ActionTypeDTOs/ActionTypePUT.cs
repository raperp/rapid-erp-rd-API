using RapidERP.Application.DTOs.Shared;

namespace RapidERP.Application.DTOs.ActionTypeDTOs;

public record ActionTypePUT : BaseConfigDTO
{
    public int Id { get; set; }
    public string Description { get; set; }
}
