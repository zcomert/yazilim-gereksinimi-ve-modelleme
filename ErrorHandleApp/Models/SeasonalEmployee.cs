namespace ErrorHandleApp.Models;

// SeasonalEmployee is an Employee
public class SeasonalEmployee : Employee
{
    public SeasonalEmployee(int id,
    string? firstName,
    string? lastName,
    double salary) : base(id, firstName, lastName, salary)
    {

    }

    public double SeasonalSalary => Salary / 2;
}

