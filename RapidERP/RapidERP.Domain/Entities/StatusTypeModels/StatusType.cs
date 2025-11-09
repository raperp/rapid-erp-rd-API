using RapidERP.Domain.Entities.LanguageModels;
using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Domain.Entities.StatusTypeModels;
public class StatusType : BaseMaster
{
    public Language Language { get; set; }
    public int LanguageId { get; set; }
    public string Description { get; set; }
}
