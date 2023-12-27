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
    public IActionResult GetAllEmployees([FromQuery(Name ="q")] string q="")
    {
        List<Employee> employees;
        
        if(string.IsNullOrWhiteSpace(q))
            employees = _context.Employees.ToList();
        else
            employees = _context
                .Employees
                .Where(emp => emp.FirstName.ToLower().Contains(q))
                .ToList();
                
        return Ok(employees);
    }

    [HttpGet("orderbyname")]
    public IActionResult GetAllEmployeesOrderByFirstName()
    {
        var employees = _context
        .Employees
        .OrderBy(emp => emp.FirstName)
        .ThenBy(emp => emp.LastName)
        .ToList();
        
        return Ok(employees);
    }
    
    // filter/?min=a&max=b

    [HttpGet("filter")]
    public IActionResult Filter([FromQuery(Name ="min")] decimal min, 
        [FromQuery(Name ="max")]decimal max)
    {

        // var employees = new List<Employee>();

        // foreach (var item in _context.Employees.ToList())
        // {
        //     if(item.Salary>=min && item.Salary<=max)
        //     {
        //         employees.Add(item);
        //     }
        // }
        // return Ok(employees);

        var model = _context
            .Employees
            .Where(c => c.Salary>=min && c.Salary<=max)
            .ToList();

        return Ok(model);
    }


    [HttpGet("search")]
    public IActionResult GetAllEmployeesWithSearchTerm([FromQuery(Name ="q")] string q)
    {
        return Ok("Selam caniimm...");
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