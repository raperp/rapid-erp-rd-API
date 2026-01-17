using RapidERP.Application.DTOs.DepartmentDTOs;

namespace RapidERP.Application.Features.DepartmentFeatures.CreateBulkCommand;

public record CreateBulkDepartmentCommandRequestModel(List<DepartmentPOST> masterPOSTs);
