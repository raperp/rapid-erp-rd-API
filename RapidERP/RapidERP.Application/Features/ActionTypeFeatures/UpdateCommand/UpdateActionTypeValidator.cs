using FluentValidation;
using RapidERP.Application.DTOs.ActionTypeDTOs;

namespace RapidERP.Application.Features.ActionTypeFeatures.UpdateCommand;

public class UpdateActionTypeValidator : AbstractValidator<ActionTypePUT>
{
    public UpdateActionTypeValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(10).WithMessage("Name must not exceed 10 characters."); 
    }
}
