using RapidERP.Application.DTOs.Shared;

namespace RapidERP.Application.DTOs.TableDTOs;

public record class TablePUT : BasePUT
{
    public int TotalPersons { get; set; }
    public string Description { get; set; }
}
