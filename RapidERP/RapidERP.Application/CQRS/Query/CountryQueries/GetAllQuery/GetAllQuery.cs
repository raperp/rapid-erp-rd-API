using RapidERP.Application.DTOs.CountryDTOs;

namespace RapidERP.Application.CQRS.Query.CountryQueries.GetAllQuery;

public record GetAllQuery(int skip, int take, int pageSize);
