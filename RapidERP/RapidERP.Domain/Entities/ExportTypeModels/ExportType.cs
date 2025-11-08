using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Domain.Entities.ExportTypeModels;
public class ExportType : BaseMaster
{
    public int? LanguageId { get; set; }
    public string Description { get; set; }
}
