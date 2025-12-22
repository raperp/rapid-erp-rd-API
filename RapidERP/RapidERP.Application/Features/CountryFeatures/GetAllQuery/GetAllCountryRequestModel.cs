using RapidERP.Application.DTOs.CountryDTOs;

namespace RapidERP.Application.Features.CountryFeatures.GetAllQuery;

public record GetAllCountryRequestModel(int skip, int take, int pageSize);
