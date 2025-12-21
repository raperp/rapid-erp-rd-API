using RapidERP.Application.DTOs.CountryDTOs.CountryRecord;

namespace RapidERP.Application.CQRS.Command.CountryCommands.CreateSingleCommand;

public record CreateSingleCommand(CountryPOSTRequestDTO masterPOST);
