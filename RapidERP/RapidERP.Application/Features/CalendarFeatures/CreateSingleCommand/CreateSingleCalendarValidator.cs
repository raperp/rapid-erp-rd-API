using FluentValidation;
using RapidERP.Application.DTOs.CalendarDTOs;

namespace RapidERP.Application.Features.CalendarFeatures.CreateSingleCommand;

public class CreateSingleCalendarValidator : AbstractValidator<CalendarPOST>
{
    public CreateSingleCalendarValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name can't be empty")
            .MaximumLength(10).WithMessage("Max 10 characters allowed");

        RuleFor(x => x.Code)
            .NotEmpty()
            .WithMessage("Code can't be empty")
            .MaximumLength(3).WithMessage("Max 3 characters allowed");

        RuleFor(x => x.StartDate)
            .NotEmpty()
            .WithMessage("Start Date can't be empty");

        RuleFor(x => x.EndDate)
            .NotEmpty()
            .WithMessage("End Date can't be empty");

        RuleFor(x => x.TotalMonth)
            .NotEmpty()
            .WithMessage("Total Month can't be empty");
    }
}
