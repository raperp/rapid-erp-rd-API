using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace RapidERP.Application.CQRS.CountryModule.Query.CountryMasterQueries.GetSingleQuery;

public record GetSingleCountryCommand(int id);
