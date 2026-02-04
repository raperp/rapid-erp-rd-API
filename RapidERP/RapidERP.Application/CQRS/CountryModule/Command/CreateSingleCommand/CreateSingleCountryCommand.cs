using RapidERP.Application.DTOs.CountryDTOs;

namespace RapidERP.Application.CQRS.CountryModule.Command.CreateSingleCommand;

public record CreateSingleCountryCommand(CountryPOST masterPOST);
