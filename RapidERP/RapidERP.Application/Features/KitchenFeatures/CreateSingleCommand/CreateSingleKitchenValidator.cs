using FluentValidation;
using RapidERP.Application.DTOs.KitchenDTOs;

namespace RapidERP.Application.Features.KitchenFeatures.CreateSingleCommand;

public class CreateSingleKitchenValidator : AbstractValidator<KitchenPOST>
{
    public CreateSingleKitchenValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required.")
            .MaximumLength(15)
            .WithMessage("Name must not exceed 15 characters.");
    }
}
