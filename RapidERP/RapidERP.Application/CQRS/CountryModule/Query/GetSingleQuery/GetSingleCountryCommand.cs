using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace RapidERP.Application.CQRS.CountryModule.Query.GetSingleQuery;

public record GetSingleCountryCommand(int id);
