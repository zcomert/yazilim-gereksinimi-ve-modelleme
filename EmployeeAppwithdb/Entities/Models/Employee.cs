using System.ComponentModel.DataAnnotations;

namespace Entities.Models;
public class Employee
{
    public int EmployeeId { get; set; }
    [Required(ErrorMessage = "Firstname is required.")]
    public String? FirstName { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Lastname is required.")]
    public String? LastName { get; set; } = string.Empty;
    
    [Range(100,900, ErrorMessage ="Salary must be between 100 and 900.")]
    public decimal Salary { get; set; }
    public bool Gender { get; set; }
}