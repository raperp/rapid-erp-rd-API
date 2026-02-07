using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Domain.Entities.MessageModuleModels;

public class MessageModuleHistory : BaseAudit
{
    public MessageModule MessageModule { get; set; }
    public int? MessageModuleId { get; set; }
    public int? TextModuleId { get; set; }
}
