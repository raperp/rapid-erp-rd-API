using RapidERP.Application.DTOs.Shared;

namespace RapidERP.Application.DTOs.SubmoduleDTOs;

public class SubmodulePOST : BasePOST
{
    public int MainModuleId { get; set; }
    public string Prefix { get; set; }
}