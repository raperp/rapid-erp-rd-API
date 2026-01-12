using FluentValidation;
using RapidERP.Application.DTOs.StatusTypeDTOs;

namespace RapidERP.Application.Features.StatusTypeFeatures.CreateSingleCommand;

public class CreateSingleStatusTypeValidator : AbstractValidator<StatusTypePOST>
{
    public CreateSingleStatusTypeValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name can't be empty")
            .MaximumLength(15);
    }
}
