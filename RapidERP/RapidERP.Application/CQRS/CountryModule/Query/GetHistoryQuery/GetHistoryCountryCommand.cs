namespace RapidERP.Application.CQRS.CountryModule.Query.GetHistoryQuery;

public record GetHistoryCountryCommand(int skip, int take, int pageSize);
