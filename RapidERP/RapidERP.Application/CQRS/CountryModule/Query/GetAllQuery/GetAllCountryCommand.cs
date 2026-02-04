namespace RapidERP.Application.CQRS.CountryModule.Query.GetAllQuery;

public record GetAllCountryCommand(int skip, int take, int pageSize);
