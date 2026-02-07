using FluentValidation;

namespace RapidERP.Application.CQRS.CountryModule.Command.CountryExportCommands.Create;

public class CreateCountryExportValidator : AbstractValidator<CreateCountryExportCommand>
{
    public CreateCountryExportValidator()
    {
        
    }
}
