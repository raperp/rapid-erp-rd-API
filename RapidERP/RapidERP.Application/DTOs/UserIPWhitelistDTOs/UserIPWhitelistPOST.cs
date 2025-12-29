using RapidERP.Application.DTOs.Shared;

namespace RapidERP.Application.DTOs.UserIPWhitelistDTOs;

public record class UserIPWhitelistPOST : TrackerDTO
{
    public int UserId { get; set; }
    public string IPAddress { get; set; }
    public int StatusTypeId { get; set; }
    public int ActionTypeId { get; set; }
    public int ExportTypeId { get; set; }
    public string ExportTo { get; set; }
    public string SourceURL { get; set; }
}
