using RapidERP.Application.DTOs.TenantDTOs.TenantDTOs;

namespace RapidERP.Application.Features.TenantFeatures.CreateBulkCommand;

public record CreateBulkTenantCommandRequestModel(List<TenantPOST> masterPOSTs) { }
