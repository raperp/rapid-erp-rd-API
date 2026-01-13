using FluentValidation;
using RapidERP.Application.DTOs.MessageModuleDTOs;

namespace RapidERP.Application.Features.MessageModuleFeatures.CreateSingleCommand;

public class CreateSingleMessageModuleValidator : AbstractValidator<MessageModulePOST>
{
    public CreateSingleMessageModuleValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name can't be empty")
            .MaximumLength(15).WithMessage("Max 15 characters allowed");
    }
}
