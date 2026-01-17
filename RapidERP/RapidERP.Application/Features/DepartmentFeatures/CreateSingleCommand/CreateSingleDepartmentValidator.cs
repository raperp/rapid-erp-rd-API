using FluentValidation;
using RapidERP.Application.DTOs.DepartmentDTOs;

namespace RapidERP.Application.Features.DepartmentFeatures.CreateSingleCommand;

public class CreateSingleDepartmentValidator : AbstractValidator<DepartmentPOST>
{
    public CreateSingleDepartmentValidator()
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
