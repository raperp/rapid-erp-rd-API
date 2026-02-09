using FluentValidation;
using RapidERP.Application.DTOs.CurrencyDTOs;

namespace RapidERP.Application.Features.CurrencyFeatures.CreateSingleCommand;

public class CreateSingleCurrencyValidator : AbstractValidator<CurrencyPOST>
{
    public CreateSingleCurrencyValidator()
    {
        RuleFor(x => x.TenantId)
            .GreaterThan(0)
            .WithMessage("Tenant is required.");

        //RuleFor(x => x.MenuModuleId)
        //    .GreaterThan(0)
        //    .WithMessage("Menu module is required.");

        //RuleFor(x => x.LanguageId)
        //    .GreaterThan(0)
        //    .WithMessage("Language is required.");

        //RuleFor(x => x.StatusTypeId)
        //    .GreaterThan(0)
        //    .WithMessage("Status type is required.");

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

        RuleFor(x => x.Icon)
            .MaximumLength(255)
            .WithMessage("Icon must not exceed 255 characters.")
            .When(x => !string.IsNullOrWhiteSpace(x.Icon));

        RuleFor(x => x.IsDefault)
            .NotNull()
            .WithMessage("IsDefault must be specified.");

        RuleFor(x => x.IsDraft)
            .NotNull()
            .WithMessage("IsDraft must be specified.");
    }
}
