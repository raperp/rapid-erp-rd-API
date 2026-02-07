using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Domain.Entities.TextModuleModels;

public class TextModuleHistory : BaseAudit 
{
    public TextModule TextModule { get; set; }
    public int? TextModuleId { get; set; }
}
