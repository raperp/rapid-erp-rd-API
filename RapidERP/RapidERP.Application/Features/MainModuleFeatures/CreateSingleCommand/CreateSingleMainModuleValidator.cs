using FluentValidation;
using RapidERP.Application.DTOs.MainModuleDTOs;

namespace RapidERP.Application.Features.MainModuleFeatures.CreateSingleCommand;

public class CreateSingleMainModuleValidator : AbstractValidator<MainModulePOST>
{
    public CreateSingleMainModuleValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(30).WithMessage("Name cannot exceed 30 characters.");

        RuleFor(x => x.Prefix)
            .MaximumLength(4).WithMessage("Description cannot exceed 4 characters.");

        RuleFor(x => x.IconURL).NotEmpty().WithMessage("Icon URL is required");
        RuleFor(x => x.SetSerial).NotEmpty().WithMessage("Set Serial is required");
    }
}
