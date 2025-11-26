using RapidERP.Application.DTOs.Shared;

namespace RapidERP.Application.DTOs.MenuModuleDTOs;

public class MenuModulePOST : BasePOST
{
    public int SubmoduleId { get; set; }
    public string Prefix { get; set; }
    public string IconURL { get; set; }
}
