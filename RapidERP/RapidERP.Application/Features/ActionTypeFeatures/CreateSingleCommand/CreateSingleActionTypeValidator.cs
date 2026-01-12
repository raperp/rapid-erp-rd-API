using FluentValidation;
using RapidERP.Application.DTOs.ActionTypeDTOs;

namespace RapidERP.Application.Features.ActionTypeFeatures.CreateSingleCommand;

public class CreateSingleActionTypeValidator : AbstractValidator<ActionTypePOST>
{
    public CreateSingleActionTypeValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name can't be empty")
            .MaximumLength(10);
    }
}
