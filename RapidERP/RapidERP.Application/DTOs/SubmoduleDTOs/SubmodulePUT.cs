using RapidERP.Application.DTOs.Shared;

namespace RapidERP.Application.DTOs.SubmoduleDTOs;

public class SubmodulePUT : BasePUT
{
    public int MainModuleId { get; set; }
    public string Prefix { get; set; }
}
