namespace Repositories.Services.Exceptions;

public class BadRequestException : Exception
{
    public BadRequestException(string message = "Required area have wrong value!") : base(message)
    { }
}
