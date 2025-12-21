using FluentValidation;
using RapidERP.Application.DTOs.CountryDTOs.CountryRecord;

namespace RapidERP.Application.CQRS.Command.CountryCommands.UpdateCommand;

public class UpdateValidator : AbstractValidator<CountryPUTRequestDTO>
{
    public UpdateValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id can't be empty");

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name can't be empty")
            .MaximumLength(40);

        RuleFor(x => x.DialCode)
            .NotEmpty()
            .WithMessage("Dial Code can't be empty")
            .MaximumLength(4);

        RuleFor(x => x.ISO3Code)
            .NotEmpty()
            .WithMessage("ISO3Code can't be empty")
            .MaximumLength(3);

        RuleFor(x => x.ISO2Code)
            .NotEmpty()
            .WithMessage("ISO2Code can't be empty")
            .MaximumLength(2);

        RuleFor(x => x.ISONumeric)
            .NotEmpty()
            .WithMessage("ISONumeric can't be empty")
            .MaximumLength(4);

        RuleFor(x => x.MenuModuleId)
            .NotEmpty()
            .WithMessage("MenuModuleId can't be empty");

        RuleFor(x => x.TenantId)
            .NotEmpty()
            .WithMessage("TenantId can't be empty");

        RuleFor(x => x.StatusTypeId)
            .NotEmpty()
            .WithMessage("StatusTypeId can't be empty");

        RuleFor(x => x.LanguageId)
            .NotEmpty()
            .WithMessage("LanguageId can't be empty");

        RuleFor(x => x.IsDefault)
            .NotEmpty()
            .WithMessage("IsDefault can't be empty");

        RuleFor(x => x.IsDraft)
            .NotEmpty()
            .WithMessage("IsDraft can't be empty");

        RuleFor(x => x.ActionBy)
            .NotEmpty()
            .WithMessage("ActionBy can't be empty");
    }
}
