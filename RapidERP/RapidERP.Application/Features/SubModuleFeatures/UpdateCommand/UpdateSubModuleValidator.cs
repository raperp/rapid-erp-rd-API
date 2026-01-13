using FluentValidation;
using RapidERP.Application.DTOs.SubmoduleDTOs;

namespace RapidERP.Application.Features.SubModuleFeatures.UpdateCommand;

public class UpdateSubModuleValidator : AbstractValidator<SubmodulePUT>
{
    public UpdateSubModuleValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Submodule name is required.")
            .MaximumLength(20).WithMessage("Submodule name must not exceed 20 characters.");

        RuleFor(x => x.IconURL)
            .NotEmpty().WithMessage("Icon URL is required.");

    }
}
