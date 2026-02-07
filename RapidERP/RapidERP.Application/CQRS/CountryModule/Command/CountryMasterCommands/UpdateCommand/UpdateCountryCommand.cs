using RapidERP.Application.DTOs.CountryDTOs;

namespace RapidERP.Application.CQRS.CountryModule.Command.CountryMasterCommands.UpdateCommand;

public record UpdateCountryCommand(CountryPUT masterPUT);
