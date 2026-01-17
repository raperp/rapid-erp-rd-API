using FluentValidation;
using RapidERP.Application.DTOs.DesignationDTOs;

namespace RapidERP.Application.Features.DesignationFeatures.CreateSingleCommand;

public class CreateSingleDesignationValidator : AbstractValidator<DesignationPOST>
{
    public CreateSingleDesignationValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required.")
            .MaximumLength(100)
            .WithMessage("Name must not exceed 100 characters.");

        RuleFor(x => x.Description)
            .MaximumLength(200)
            .WithMessage("Description must not exceed 200 characters.")
            .When(x => !string.IsNullOrWhiteSpace(x.Description));
    }
}
