namespace ErrorHandleApp.Models.Exceptions;

public class EmployeeNotFoundException : NotFoundException
{
    public EmployeeNotFoundException(int id)
        : base($"The fulltime employee with id:{id}")
    {

    }
}
