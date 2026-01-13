using FluentValidation;
using RapidERP.Application.DTOs.MessageModuleDTOs;

namespace RapidERP.Application.Features.MessageModuleFeatures.UpdateCommand;

public class UpdateMessageModuleValidator : AbstractValidator<MessageModulePUT>
{
    public UpdateMessageModuleValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name can't be empty")
            .MaximumLength(15).WithMessage("Max 15 characters allowed");
    }
}
