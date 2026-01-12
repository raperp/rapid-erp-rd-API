using RapidERP.Application.DTOs.StatusTypeDTOs;

namespace RapidERP.Application.Features.StatusTypeFeatures.CreateBulkCommand;

public record CreateBulkStatusTypeCommandRequestModel(List<StatusTypePOST> masterPOSTs);
