using RapidERP.Domain.Entities.Shared;
using RapidERP.Domain.Entities.TextModuleModels;

namespace RapidERP.Domain.Entities.MessageModuleModels;

public class MessageModule : BaseMaster
{
    public TextModule TextModule { get; set; }
    public int? TextModuleId { get; set; }
}
