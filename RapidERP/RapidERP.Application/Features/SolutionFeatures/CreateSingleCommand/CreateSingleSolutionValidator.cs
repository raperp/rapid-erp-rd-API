using FluentValidation;
using RapidERP.Application.DTOs.SolutionDTOs;

namespace RapidERP.Application.Features.SolutionFeatures.CreateSingleCommand;

public class CreateSingleSolutionValidator : AbstractValidator<SolutionPOST>
{
    public CreateSingleSolutionValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name can't be empty")
            .MaximumLength(10).WithMessage("Max 10 characters allowed");

        RuleFor(x => x.Code)
            .NotEmpty()
            .WithMessage("Code can't be empty")
            .MaximumLength(3).WithMessage("Max 3 characters allowed");
    }
}
