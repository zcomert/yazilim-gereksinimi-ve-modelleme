namespace ErrorHandleApp.Models;

public class FullTimeEmployee : Employee
{
    public FullTimeEmployee(int id, string? firstName, string? lastName, double salary) :
        base(id, firstName, lastName, salary)
    {

    }
}

