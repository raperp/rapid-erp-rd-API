using RapidERP.Application.DTOs.Shared;

namespace RapidERP.Application.DTOs.TableDTOs;

public record class TablePOST : BasePOST
{
    public int TotalPersons { get; set; }
    public string Description { get; set; }
}
