using RapidERP.Application.DTOs.Shared;

namespace RapidERP.Application.DTOs.CountryDTOs;

public record CountryExportDTO : ExportDTO
{
    public int CountryId { get; set; }
}
