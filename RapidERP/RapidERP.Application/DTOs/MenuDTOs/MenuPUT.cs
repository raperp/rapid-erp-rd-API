using RapidERP.Application.DTOs.Shared;

namespace RapidERP.Application.DTOs.MenuDTOs;

public class MenuPUT : BasePUT
{
    public int SubModuleId { get; set; }
    public string Prefix { get; set; }
    public string IconURL { get; set; }
}
