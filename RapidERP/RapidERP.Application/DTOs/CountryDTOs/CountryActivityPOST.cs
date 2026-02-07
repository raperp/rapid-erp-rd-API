using RapidERP.Application.DTOs.Shared;

namespace RapidERP.Application.DTOs.CountryDTOs;

public record CountryActivityPOST : TrackerDTO
{
    public int CountryId { get; set; }
}
