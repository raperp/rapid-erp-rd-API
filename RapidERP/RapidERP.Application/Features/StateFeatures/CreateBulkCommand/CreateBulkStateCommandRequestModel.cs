using RapidERP.Application.DTOs.StateDTOs;

namespace RapidERP.Application.Features.StateFeatures.CreateBulkCommand;

public record CreateBulkStateCommandRequestModel(List<StatePOST> masterPOSTs);
