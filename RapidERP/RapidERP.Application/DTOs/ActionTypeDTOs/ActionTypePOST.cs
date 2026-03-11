using RapidERP.Application.DTOs.Shared;

namespace RapidERP.Application.DTOs.ActionTypeDTOs;

public record class ActionTypePOST : BaseConfigDTO
{ 
    public string Description { get; set; }
}
