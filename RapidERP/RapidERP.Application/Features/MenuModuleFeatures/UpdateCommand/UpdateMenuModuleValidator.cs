using FluentValidation;
using RapidERP.Application.DTOs.MenuModuleDTOs;

namespace RapidERP.Application.Features.MenuModuleFeatures.UpdateCommand;

public class UpdateMenuModuleValidator : AbstractValidator<MenuModulePUT>
{
    public UpdateMenuModuleValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name can't be empty")
            .MaximumLength(20);

        RuleFor(x => x.SetSerial)
            .NotEmpty()
            .WithMessage("Set Serial can't be empty");
    }
}
