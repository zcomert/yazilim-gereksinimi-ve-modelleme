namespace Entities.Models;
public class Employee
{
    public int EmployeeId { get; set; }
    public String? FirstName { get; set; } = string.Empty;
    public String? LastName { get; set; } = string.Empty;
    public decimal Salary { get; set; }
}