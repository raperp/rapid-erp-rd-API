using RapidERP.Application.Interfaces;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.CQRS.Query.CountryQueries.GetAllQuery;

public class GetAllQueryHandler(ICountryService country)
{
    public async Task<RequestResponse> Handle(GetAllQuery query, CancellationToken cancellationToken)
    {
        var getAll = await country.GetAll(query.skip, query.take, query.pageSize);
        return getAll;
    }
}
