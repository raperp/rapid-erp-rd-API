using RapidERP.Application.DTOs.CountryDTOs;

namespace RapidERP.Application.CQRS.CountryModule.Command.CreateCountryLocalization;

public record CreateCountryLocalizationCommand(CountryLocalizationPOST localization);