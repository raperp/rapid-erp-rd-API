using RapidERP.Application.DTOs.CountryDTOs;

namespace RapidERP.Application.CQRS.CountryModule.Command.CountryExportCommands.Create;

public record CreateCountryExportCommand(CountryExportDTO export);
