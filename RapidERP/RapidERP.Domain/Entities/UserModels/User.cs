using RapidERP.Domain.Entities.Shared;

namespace RapidERP.Domain.Entities.UserModels;

public class User : BaseMaster
{
    public long Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Mobile { get; set; }
    public string Address { get; set; }
    public string Password { get; set; }
    public string OTP { get; set; }
}
