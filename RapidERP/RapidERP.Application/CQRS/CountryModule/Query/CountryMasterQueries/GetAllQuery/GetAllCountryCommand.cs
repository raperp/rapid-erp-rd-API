namespace RapidERP.Application.CQRS.CountryModule.Query.CountryMasterQueries.GetAllQuery;

public record GetAllCountryCommand(int skip, int take, int pageSize);
