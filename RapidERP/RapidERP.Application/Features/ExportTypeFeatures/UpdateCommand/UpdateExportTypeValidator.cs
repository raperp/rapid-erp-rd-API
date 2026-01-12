using FluentValidation;
using RapidERP.Application.DTOs.ExportTypeDTOs;

namespace RapidERP.Application.Features.ExportTypeFeatures.UpdateCommand;

public class UpdateExportTypeValidator : AbstractValidator<ExportTypePUT>
{
    public UpdateExportTypeValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(10).WithMessage("Name must not exceed 100 characters.");
    }
}
