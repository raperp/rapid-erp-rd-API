using RapidERP.Application.DTOs.ExportTypeDTOs;

namespace RapidERP.Application.Features.ExportTypeFeatures.CreateBulkCommand;

public record CreateBulkExportTypeCommandRequestModel(List<ExportTypePOST> masterPOSTs);
