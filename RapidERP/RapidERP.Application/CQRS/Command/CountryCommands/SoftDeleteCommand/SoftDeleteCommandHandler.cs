using RapidERP.Application.Interfaces;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.CQRS.Command.CountryCommands.SoftDeleteCommand;

public class SoftDeleteCommandHandler(ISharedService shared)
{
    public async Task<RequestResponse> Handle(int id, CancellationToken cancellationToken)
    {
        var softDelete = await shared.SoftDelete<RapidERP.Domain.Entities.CountryModels.Country>(id);
        return softDelete;
    }
}
