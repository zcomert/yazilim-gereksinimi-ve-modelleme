namespace EmployeeApp.Models;

public class Employee
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = "";
    public string Company { get; set; }
    public Employee()
    {
        Company = string.Empty;
    }
}
