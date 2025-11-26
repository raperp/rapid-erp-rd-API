using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Domain.Entities.MessageModuleModels;

public class MessageModuleAudit : BaseAudit
{
    public MessageModule MessageModule { get; set; }
    public int? MessageModuleId { get; set; }
    public int? TextModuleId { get; set; }
}
