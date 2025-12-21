using RapidERP.Application.Interfaces;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.CQRS.Command.CountryCommands.DeleteCommand;

public class DeleteCommandHandler(ICountryService country)
{
    public async Task<RequestResponse> Handle(DeleteCommand request, CancellationToken cancellationToken)
    {
        var delete = await country.Delete(request.id);
        return delete;
    }
}
