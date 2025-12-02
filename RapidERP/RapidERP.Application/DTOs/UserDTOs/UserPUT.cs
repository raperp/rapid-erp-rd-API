using RapidERP.Application.DTOs.Shared;

namespace RapidERP.Application.DTOs.UserDTOs;

public class UserPUT : TrackerDTO
{
    public int Id { get; set; }
    public int RoleId { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Mobile { get; set; }
    public string Address { get; set; }
    public string Password { get; set; }
    public string OTP { get; set; }
    public string Name { get; set; }
    public int StatusTypeId { get; set; }
    public int? ActionTypeId { get; set; }
    public int? ExportTypeId { get; set; }
    public string ExportTo { get; set; }
    public string SourceURL { get; set; }
}
