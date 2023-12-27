using System.Text.Json;

namespace Entities.Exceptions;

public class ErrorDetail
{
    public int StatusCode { get; set; }
    public String Message { get; set; }
    public DateTime AtOccuredTime { get; set; } = DateTime.Now;

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}