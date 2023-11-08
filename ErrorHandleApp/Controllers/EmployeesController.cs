using ErrorHandleApp.Models;
using ErrorHandleApp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ErrorHandleApp.Controllers;

[ApiController]
[Route("/api/employees")]
public class EmployeesController : ControllerBase
{
    private readonly EmployeeRepository _employeeRepository;

    public EmployeesController(EmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    [HttpGet]
    public IActionResult GetAllEmployees()
    {
        return Ok(_employeeRepository.GetAllEmployees());
    }

    [HttpGet("{id:int}")] // api/employees/:id
    public IActionResult GetOneEmployee(int id)
    {
        return Ok(_employeeRepository.GetOneEmployee(id));
    }
}
