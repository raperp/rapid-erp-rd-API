using FluentValidation;
using RapidERP.Application.DTOs.SubmoduleDTOs;

namespace RapidERP.Application.Features.SubModuleFeatures.CreateSingleCommand;

public class CreateSingleSubModuleValidator : AbstractValidator<SubmodulePOST>
{
    public CreateSingleSubModuleValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Submodule name is required.")
            .MaximumLength(20).WithMessage("Submodule name must not exceed 20 characters.");

        RuleFor(x => x.IconURL)
            .NotEmpty().WithMessage("Icon URL is required.");

    }
}
