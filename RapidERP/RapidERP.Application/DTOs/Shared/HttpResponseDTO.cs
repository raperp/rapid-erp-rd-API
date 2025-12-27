namespace RapidERP.Application.DTOs.Shared;

public class HttpResponseDTO
{
    public int StatusCode { get; set; }
    public string Message { get; set; } = string.Empty;
}
