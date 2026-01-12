using RapidERP.Application.DTOs.SubmoduleDTOs;

namespace RapidERP.Application.Features.SubModuleFeatures.CreateBulkCommand;

public record CreateBulkSubModuleCommandRequestModel(List<SubmodulePOST> masterPOSTs);
