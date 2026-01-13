using RapidERP.Application.DTOs.MessageModuleDTOs;

namespace RapidERP.Application.Features.MessageModuleFeatures.CreateBulkCommand;

public record CreateBulkMessageModuleCommandRequestModel(List<MessageModulePOST> masterPOSTs);
