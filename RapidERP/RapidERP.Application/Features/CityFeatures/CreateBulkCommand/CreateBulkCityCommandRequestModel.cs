using RapidERP.Application.DTOs.CityDTOs;

namespace RapidERP.Application.Features.CityFeatures.CreateBulkCommand;

public record CreateBulkCityCommandRequestModel(List<CityPOST> masterPOSTs);
