using RapidERP.Application.DTOs.MenuModuleDTOs;

namespace RapidERP.Application.Features.MenuModuleFeatures.CreateBulkCommand;

public record CreateBulkMenuModuleCommandRequestModel(List<MenuModulePOST> masterPOSTs);
