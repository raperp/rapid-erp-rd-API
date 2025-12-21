using RapidERP.Application.Interfaces;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.CQRS.Query.CountryQueries.GetSingleQuery;

public class GetSingleQueryHandler(ICountryService country)
{
    public async Task<RequestResponse> Handle(int id, CancellationToken cancellationToken)
    {
        var getSingle = await country.GetSingle(id);
        return getSingle;
    }
}
