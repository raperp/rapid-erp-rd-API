using RapidERP.Application.DTOs.CountryDTOs.CountryRecord;

namespace RapidERP.Application.Features.CountryFeatures.CreateBulkCommand;

public record CreateBulkCommand(List<CountryPOSTRequestDTO> masterPOSTs);
