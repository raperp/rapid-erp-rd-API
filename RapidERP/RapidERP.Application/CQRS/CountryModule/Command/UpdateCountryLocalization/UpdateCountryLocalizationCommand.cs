using RapidERP.Application.DTOs.CountryDTOs;

namespace RapidERP.Application.CQRS.CountryModule.Command.UpdateCountryLocalization;

public record UpdateCountryLocalizationCommand(CountryLocalizationPUT localization);
