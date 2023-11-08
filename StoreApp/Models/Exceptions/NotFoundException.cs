using Microsoft.AspNetCore.Http.HttpResults;

namespace StoreApp.Models.Exceptions;

public abstract class NotFoundException : Exception
{
    public NotFoundException(string message)
    : base(message)
    {

    }
}
