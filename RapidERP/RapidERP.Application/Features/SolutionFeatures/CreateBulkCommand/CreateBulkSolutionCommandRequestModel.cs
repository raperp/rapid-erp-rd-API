using RapidERP.Application.DTOs.SolutionDTOs;

namespace RapidERP.Application.Features.SolutionFeatures.CreateBulkCommand;

public record CreateBulkSolutionCommandRequestModel(List<SolutionPOST> masterPOSTs);
