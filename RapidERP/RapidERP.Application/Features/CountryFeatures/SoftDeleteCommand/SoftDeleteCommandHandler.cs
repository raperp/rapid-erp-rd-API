using RapidERP.Application.Interfaces;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.Features.CountryFeatures.SoftDeleteCommand;

public class SoftDeleteCommandHandler(ISharedService shared)
{
    public async Task<RequestResponse> Handle(int id, CancellationToken cancellationToken)
    {
        var softDelete = await shared.SoftDelete<Domain.Entities.CountryModels.Country>(id);
        return softDelete;
    }
}
