using System.Text.Json;

namespace ErrorHandleApp.Models.ErrorModel;


// "{"StatusCode":"200", "Message":"Error message..."}"
public class ErrorDetails
{
    public int StatusCode { get; set; }
    public String? Message { get; set; }
    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}