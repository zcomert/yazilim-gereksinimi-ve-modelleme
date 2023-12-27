using System.Text.Json;

namespace Entities.Exceptions;

public class ErrorDetail
{
    public ErrorDetail()
    {
        
    }
    public ErrorDetail(int statusCode, string? message)
    {
        StatusCode = statusCode;
        Message = message;
    }

    public int StatusCode { get; set; }
    public String? Message { get; set; }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}