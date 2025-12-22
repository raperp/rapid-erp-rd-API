using RapidERP.Application.Interfaces;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.CountryFeatures.CreateBulkCommand;

public class CreateBulkCommandHandler(ICountryService country)
{
    public async Task<RequestResponse> Handle(CreateBulkCommand request, CancellationToken cancellationToken)
    {
        var create = await country.CreateBulk(request.masterPOSTs);
        return create;
    }
}
