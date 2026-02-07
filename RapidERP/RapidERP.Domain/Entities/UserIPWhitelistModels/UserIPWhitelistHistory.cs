using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Domain.Entities.UserIPWhitelistModels;

public class UserIPWhitelistHistory : BaseAudit
{
    public UserIPWhitelist UserIPWhitelist { get; set; }
    public int? UserIPWhitelistId { get; set; }
    public int UserId { get; set; }
    public string IPAddress { get; set; }
}
