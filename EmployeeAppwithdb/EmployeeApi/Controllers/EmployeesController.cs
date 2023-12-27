using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace EmployeeApi.Controllers;

[ApiController]
[Route("api/employees")]
public class EmployeesController : ControllerBase
{
    private readonly RepositoryContext _context;

    public EmployeesController(RepositoryContext context)
    {
        _context = context;
    }
    [HttpGet]
    public IActionResult GetAllEmployees()
    {
        var employees = _context.Employees.ToList();
        return Ok(employees);
    }

    [HttpGet("{id:int}")]
    public IActionResult GetOneEmployee([FromRoute(Name ="id")] int id)
    {
        var employee = _context
        .Employees
        .SingleOrDefault(e => e.EmployeeId.Equals(id));

        if(employee is null)
            throw new EmployeeNotFoundException(id); // 404
        
        return Ok(employee); // 200
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteOneEmployee(int id)
    {
        var employee = _context
        .Employees
        .SingleOrDefault(e => e.EmployeeId.Equals(id));

        _context.Employees.Remove(employee);
        _context.SaveChanges();

        return NoContent();
    }

    [HttpPost]
    public IActionResult CreateOneEmployee(Employee employee)
    {
        _context.Employees.Add(employee);
        _context.SaveChanges();
        return NoContent(); // 204
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateOneEmployee(int id, Employee employee)
    {
        var emp = _context
        .Employees
        .SingleOrDefault(e => e.EmployeeId.Equals(id));

        if(emp is not null)
        {
            emp.FirstName = employee.FirstName;
            emp.LastName = employee.LastName;
            emp.Salary = employee.Salary;

            _context.SaveChanges();
        }
        return NoContent(); // 204
    }
}