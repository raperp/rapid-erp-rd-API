using FluentValidation;
using RapidERP.Application.DTOs.AreaDTOs;

namespace RapidERP.Application.Features.AreaFeatures.CreateSingleCommand;

public class CreateSingleAreaValidator : AbstractValidator<AreaPOST>
{
    public CreateSingleAreaValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required.")
            .MaximumLength(40)
            .WithMessage("Name must not exceed 40 characters.");

        RuleFor(x => x.Code)
            .MaximumLength(3)
            .WithMessage("Code must not exceed 3 characters.")
            .When(x => !string.IsNullOrWhiteSpace(x.Code));
    }
}
