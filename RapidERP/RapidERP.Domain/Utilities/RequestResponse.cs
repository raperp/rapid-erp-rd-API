namespace RapidERP.Domain.Utilities;

#nullable enable
public record RequestResponse
{
    public string StatusCode { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
    public bool IsSuccess { get; set; }
    public object? Data { get; set; } 
}
