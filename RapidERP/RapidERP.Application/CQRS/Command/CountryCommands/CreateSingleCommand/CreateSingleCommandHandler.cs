using RapidERP.Application.Interfaces;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.CQRS.Command.CountryCommands.CreateSingleCommand;

public class CreateSingleCommandHandler(ICountryService country)
{
    public async Task<RequestResponse> Handle(CreateSingleCommand request, CancellationToken cancellationToken)
    {
        var create = await country.CreateSingle(request.masterPOST);
        return create;
    }
}
