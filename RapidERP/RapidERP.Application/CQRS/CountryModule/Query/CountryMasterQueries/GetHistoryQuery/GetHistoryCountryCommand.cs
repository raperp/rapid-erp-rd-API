namespace RapidERP.Application.CQRS.CountryModule.Query.CountryMasterQueries.GetHistoryQuery;

public record GetHistoryCountryCommand(int skip, int take, int pageSize);
