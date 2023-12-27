namespace Repositories.Services.Exceptions;

public sealed class InternalServerException : Exception
{
    public InternalServerException(string message="Internal Server Error") : base(message)
    {
        
    }
}