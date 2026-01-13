using FluentValidation;
using RapidERP.Application.DTOs.TextModuleDTOs;

namespace RapidERP.Application.Features.TextModuleFeatures.CreateSingleCommand;

public class CreateSingleTextModuleValidator : AbstractValidator<TextModulePOST>
{
    public CreateSingleTextModuleValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name can't be empty")
            .MaximumLength(20).WithMessage("Max 20 characters allowed");
    }
}
