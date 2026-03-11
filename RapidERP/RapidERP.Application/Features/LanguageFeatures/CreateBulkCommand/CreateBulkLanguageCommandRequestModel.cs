using RapidERP.Application.DTOs.LanguageDTOs.LanguageMaster;

namespace RapidERP.Application.Features.LanguageFeatures.CreateBulkCommand;

public record CreateBulkLanguageCommandRequestModel(List<LanguagePOST> masterPOSTs);
