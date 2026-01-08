using FluentValidation;
using RapidERP.Application.DTOs.LanguageDTOs;

namespace RapidERP.Application.Features.LanguageFeatures.UpdateCommand;

public class UpdateLanguageValidator : AbstractValidator<LanguagePUT>
{
    public UpdateLanguageValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name can't be empty").MaximumLength(40);
        RuleFor(x => x.ISONumeric).NotEmpty().WithMessage("ISO Numeric can't be empty").MaximumLength(4);
        RuleFor(x => x.ISO2Code).NotEmpty().WithMessage("ISO2 Code can't be empty").MaximumLength(2);
        RuleFor(x => x.IconURL).NotEmpty().WithMessage("Icon URL can't be empty");//.MaximumLength(3);
        RuleFor(x => x.Browser).NotEmpty().WithMessage("Browser can't be empty").MaximumLength(15);
        RuleFor(x => x.Location).NotEmpty().WithMessage("Location can't be empty").MaximumLength(40);
        RuleFor(x => x.DeviceIP).NotEmpty().WithMessage("Device IP can't be empty").MaximumLength(15);
        RuleFor(x => x.LocationURL).NotEmpty().WithMessage("Location URL can't be empty");
        RuleFor(x => x.DeviceName).NotEmpty().WithMessage("Device Name can't be empty").MaximumLength(10);
        RuleFor(x => x.Latitude).NotEmpty().WithMessage("Latitude can't be null");
        RuleFor(x => x.Longitude).NotEmpty().WithMessage("Longitude can't be null");
        RuleFor(x => x.ActionBy).NotEmpty().WithMessage("Action By can't be zero");
    }
}
