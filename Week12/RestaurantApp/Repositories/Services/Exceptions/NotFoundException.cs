namespace Repositories.Services.Exceptions;

public sealed class NotFoundException : Exception
{
    public NotFoundException(int id) : base($"Item with {id} not found!") { }
}