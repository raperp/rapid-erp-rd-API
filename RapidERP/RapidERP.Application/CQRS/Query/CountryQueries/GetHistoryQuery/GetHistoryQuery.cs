namespace RapidERP.Application.CQRS.Query.CountryQueries.GetHistoryQuery;

public record GetHistoryQuery(int skip, int take, int pageSize);
