using FluentValidation;
using RapidERP.Application.DTOs.StateDTOs;

namespace RapidERP.Application.Features.StateFeatures.UpdateCommand;

public class UpdateStateValidator : AbstractValidator<StatePUT>
{
    public UpdateStateValidator()
    {
        RuleFor(x => x.MenuModuleId)
            .GreaterThan(0)
            .WithMessage("Menu module is required.");

        RuleFor(x => x.CountryId)
            .GreaterThan(0)
            .WithMessage("Country is required.");

        RuleFor(x => x.StatusTypeId)
            .GreaterThan(0)
            .WithMessage("Status type is required.");

        RuleFor(x => x.LanguageId)
            .GreaterThan(0)
            .WithMessage("Language is required.");

        RuleFor(x => x.Code)
            .NotEmpty()
            .WithMessage("Code is required.")
            .MaximumLength(4)
            .WithMessage("Code must not exceed 4 characters.");

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required.")
            .MaximumLength(40)
            .WithMessage("Name must not exceed 40 characters.");

        RuleFor(x => x.IsDefault)
            .NotNull()
            .WithMessage("IsDefault must be specified.");

        RuleFor(x => x.IsDraft)
            .NotNull()
            .WithMessage("IsDraft must be specified.");
    }
}
