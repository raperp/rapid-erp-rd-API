using RapidERP.Application.DTOs.AreaDTOs;

namespace RapidERP.Application.Features.AreaFeatures.CreateBulkCommand;

public record CreateBulkAreaCommandRequestModel(List<AreaPOST> masterPOSTs);
