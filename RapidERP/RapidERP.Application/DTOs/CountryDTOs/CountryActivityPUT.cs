using RapidERP.Application.DTOs.Shared;

namespace RapidERP.Application.DTOs.CountryDTOs;

public record CountryActivityPUT : TrackerDTO
{
    public int Id { get; set; }
    public int CountryId { get; set; }
}
