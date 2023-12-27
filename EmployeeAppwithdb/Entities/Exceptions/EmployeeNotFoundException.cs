namespace Entities.Exceptions;

public class EmployeeNotFoundException : NotFoundException
{
    public EmployeeNotFoundException(int id) 
        : base($"Employee with id: {id} not found.")
    {
        
    }
}