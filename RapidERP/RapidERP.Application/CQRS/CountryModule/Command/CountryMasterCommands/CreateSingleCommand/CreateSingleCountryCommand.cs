using RapidERP.Application.DTOs.CountryDTOs;

namespace RapidERP.Application.CQRS.CountryModule.Command.CountryMasterCommands.CreateSingleCommand;

public record CreateSingleCountryCommand(CountryPOST masterPOST);
