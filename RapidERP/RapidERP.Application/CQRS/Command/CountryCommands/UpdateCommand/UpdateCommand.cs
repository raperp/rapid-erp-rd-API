using RapidERP.Application.DTOs.CountryDTOs.CountryRecord;

namespace RapidERP.Application.CQRS.Command.CountryCommands.UpdateCommand;

public record UpdateCommand(CountryPUTRequestDTO masterPUT);
 
