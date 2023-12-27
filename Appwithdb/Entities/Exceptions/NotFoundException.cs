namespace Entities.Exceptions;

public abstract class NotFoundException : Exception   
{
    public NotFoundException(string message) 
        : base(message)
    {
        
    }
}