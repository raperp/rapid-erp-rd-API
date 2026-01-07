using RapidERP.Application.DTOs.LanguageDTOs;

namespace RapidERP.Application.Features.LanguageFeatures.CreateBulkCommand;

public record CreateBulkLanguageCommandRequestModel(List<LanguagePOST> masterPOSTs);
