using RapidERP.Application.DTOs.Shared;

namespace RapidERP.Application.DTOs.UserDTOs;

public class UserPOST : BasePOST
{
    public long Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Mobile { get; set; }
    public string Address { get; set; }
    public string Password { get; set; }
}
