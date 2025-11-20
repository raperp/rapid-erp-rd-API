using RapidERP.Application.DTOs.Shared;

namespace RapidERP.Application.DTOs.MainModuleDTOs;

public class MainModulePOST : BasePOST
{
    public int LanguageId { get; set; }
    public string Prefix { get; set; }
    public string IconURL { get; set; }
}
