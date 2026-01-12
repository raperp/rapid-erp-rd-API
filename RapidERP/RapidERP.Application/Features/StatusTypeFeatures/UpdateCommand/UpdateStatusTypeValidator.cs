using FluentValidation;
using RapidERP.Application.DTOs.StatusTypeDTOs;

namespace RapidERP.Application.Features.StatusTypeFeatures.UpdateCommand;

public class UpdateStatusTypeValidator : AbstractValidator<StatusTypePUT>
{
    public UpdateStatusTypeValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name can't be empty")
            .MaximumLength(15);
    }
}
