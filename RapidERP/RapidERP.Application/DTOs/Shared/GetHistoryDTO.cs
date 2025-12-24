namespace RapidERP.Application.DTOs.Shared;

public class GetHistoryDTO
{
    public int TotalCount { get; set; }
    public int TotalPages { get; set; }
    public object? Data { get; set; }
}
