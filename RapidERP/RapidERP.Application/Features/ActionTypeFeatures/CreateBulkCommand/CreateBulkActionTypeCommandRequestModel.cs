using RapidERP.Application.DTOs.ActionTypeDTOs;

namespace RapidERP.Application.Features.ActionTypeFeatures.CreateBulkCommand;

public record CreateBulkActionTypeCommandRequestModel(List<ActionTypePOST> masterPOSTs);