using RapidERP.Application.DTOs.CountryDTOs.CountryRecord;

namespace RapidERP.Application.CQRS.Command.CountryCommands.CreateBulkCommand;

public record CreateBulkCommand(List<CountryPOSTRequestDTO> masterPOSTs);
