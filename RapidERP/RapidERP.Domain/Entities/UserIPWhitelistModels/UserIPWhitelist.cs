using RapidERP.Domain.Entities.Shared;
using RapidERP.Domain.Entities.UserModels;

namespace RapidERP.Domain.Entities.UserIPWhitelistModels;

public class UserIPWhitelist : BaseMaster
{
    public User User { get; set; }
    public int UserId { get; set; }
    public string IPAddress { get; set; }
}
