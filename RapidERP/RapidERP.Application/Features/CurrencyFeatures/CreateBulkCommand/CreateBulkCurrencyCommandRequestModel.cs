using RapidERP.Application.DTOs.CurrencyDTOs;

namespace RapidERP.Application.Features.CurrencyFeatures.CreateBulkCommand;

public record CreateBulkCurrencyCommandRequestModel(List<CurrencyPOST> masterPOSTs);
