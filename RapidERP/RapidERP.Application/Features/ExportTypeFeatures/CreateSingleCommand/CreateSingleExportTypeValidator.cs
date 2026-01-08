using FluentValidation;
using RapidERP.Application.DTOs.ExportTypeDTOs;

namespace RapidERP.Application.Features.ExportTypeFeatures.CreateSingleCommand;

public class CreateSingleExportTypeValidator : AbstractValidator<ExportTypePOST>
{
    public CreateSingleExportTypeValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name can't be empty")
            .MaximumLength(5);  
    }
}
