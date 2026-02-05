using FluentValidation;
using RapidERP.Application.DTOs.TenantDTOs.TenantDTOs;

namespace RapidERP.Application.Features.TenantFeatures.UpdateCommand;

public class UpdateTenantValidator : AbstractValidator<TenantPUT>
{
    public UpdateTenantValidator()
    {
        RuleFor(x => x.MenuModuleId)
            .GreaterThan(0)
            .WithMessage("Menu module is required.");

        RuleFor(x => x.StatusTypeId)
            .GreaterThan(0)
            .WithMessage("Status type is required.");

        //RuleFor(x => x.LanguageId)
        //    .GreaterThan(0)
        //    .WithMessage("Language is required.");

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required.")
            .MaximumLength(40)
            .WithMessage("Name must not exceed 40 characters.");

        RuleFor(x => x.Contact)
            .NotEmpty()
            .WithMessage("Contact person is required.")
            .MaximumLength(30)
            .WithMessage("Contact must not exceed 30 characters.");

        RuleFor(x => x.Phone)
            .NotEmpty()
            .WithMessage("Phone number is required.")
            .MaximumLength(15)
            .WithMessage("Phone must not exceed 15 characters.");

        RuleFor(x => x.Mobile)
            .NotEmpty()
            .WithMessage("Mobile number is required.")
            .MaximumLength(15)
            .WithMessage("Mobile must not exceed 15 characters.");

        RuleFor(x => x.Address)
            .NotEmpty()
            .WithMessage("Address is required.")
            .MaximumLength(30)
            .WithMessage("Address must not exceed 30 characters.");

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email is required.")
            .MaximumLength(20)
            .WithMessage("Email must not exceed 20 characters.")
            .EmailAddress()
            .WithMessage("Please enter a valid email address.");

        RuleFor(x => x.Website)
            .NotEmpty()
            .WithMessage("Website is required.")
            .MaximumLength(20)
            .WithMessage("Website must not exceed 20 characters.")
            .WithMessage("Please enter a valid website URL.");
    }
}
