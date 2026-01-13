using FluentValidation;
using RapidERP.Application.DTOs.MenuModuleDTOs;

namespace RapidERP.Application.Features.MenuModuleFeatures.CreateSingleCommand;

public class CreateSingleMenuModuleValidator : AbstractValidator<MenuModulePOST>
{
    public CreateSingleMenuModuleValidator()
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
