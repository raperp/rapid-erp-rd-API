using RapidERP.Application.DTOs.TextModuleDTOs;

namespace RapidERP.Application.Features.TextModuleFeatures.CreateBulkCommand;

public record CreateBulkTextModuleCommandRequestModel(List<TextModulePOST> masterPOSTs);
