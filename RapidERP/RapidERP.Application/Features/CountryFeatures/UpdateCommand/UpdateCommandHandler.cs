using RapidERP.Application.Interfaces;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.CountryFeatures.UpdateCommand;

public class UpdateCommandHandler(ICountryService country)
{
    public async Task<RequestResponse> Handle(UpdateCommand request, CancellationToken cancellationToken)
    {
        var update = await country.Update(request.masterPUT);
        return update;
    }
}
