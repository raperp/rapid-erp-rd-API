using RapidERP.Application.DTOs.DesignationDTOs;

namespace RapidERP.Application.Features.DesignationFeatures.CreateBulkCommand;

public record CreateBulkDesignationCommandRequestModel(List<DesignationPOST> masterPOSTs);
