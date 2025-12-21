using RapidERP.Application.Interfaces;
using RapidERP.Domain.Utilities;

namespace RapidERP.Application.CQRS.Query.CountryQueries.GetHistoryQuery;

public class GetHistoryQueryHandler(ICountryService country)
{
    public async Task<RequestResponse> Handle(GetHistoryQuery query, CancellationToken cancellationToken)
    {
        var getHistory = await country.GetHistory(query.skip, query.take, query.pageSize);
        return getHistory;
    }
}
