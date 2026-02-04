using RapidERP.Application.DTOs.CountryDTOs;

namespace RapidERP.Application.CQRS.CountryModule.Command.UpdateCommand;

public record UpdateCountryCommand(CountryPUT masterPUT);
