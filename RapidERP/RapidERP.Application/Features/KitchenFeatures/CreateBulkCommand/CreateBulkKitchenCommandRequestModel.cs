using RapidERP.Application.DTOs.KitchenDTOs;

namespace RapidERP.Application.Features.KitchenFeatures.CreateBulkCommand;

public record CreateBulkKitchenCommandRequestModel(List<KitchenPOST> masterPOSTs);
