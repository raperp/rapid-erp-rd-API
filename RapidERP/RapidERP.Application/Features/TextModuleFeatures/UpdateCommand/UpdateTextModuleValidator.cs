using FluentValidation;
using RapidERP.Application.DTOs.TextModuleDTOs;

namespace RapidERP.Application.Features.TextModuleFeatures.UpdateCommand;

public class UpdateTextModuleValidator : AbstractValidator<TextModulePUT>
{
    public UpdateTextModuleValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name can't be empty")
            .MaximumLength(20).WithMessage("Max 20 characters allowed");
    }
}
