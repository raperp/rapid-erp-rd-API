using RapidERP.Application.DTOs.Shared;

namespace RapidERP.Application.DTOs.StatusTypeDTOs;

public record class StatusTypePOST : BaseConfigDTO
{
    public string Description { get; set; }
}
