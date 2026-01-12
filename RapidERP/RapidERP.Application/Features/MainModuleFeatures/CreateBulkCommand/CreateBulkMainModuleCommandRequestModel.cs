using RapidERP.Application.DTOs.MainModuleDTOs;

namespace RapidERP.Application.Features.MainModuleFeatures.CreateBulkCommand;

public record CreateBulkMainModuleCommandRequestModel(List<MainModulePOST> masterPOSTs);