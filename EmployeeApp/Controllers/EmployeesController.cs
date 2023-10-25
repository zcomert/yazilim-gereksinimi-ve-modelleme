
using EmployeeApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApp.Controllers
{
    [ApiController]
    [Route("api/employees")]
    public class EmployeesController : ControllerBase
    {
        public Employee[] EmployeeList { get; set; }

        private readonly ILogger<EmployeesController> _logger;
        private readonly EmployeeRepository _employeeRepository;

        public EmployeesController(ILogger<EmployeesController> logger, 
        EmployeeRepository employeeRepository)
        {
            _logger = logger;
            _employeeRepository = employeeRepository; // Resolve
        }


        [HttpGet] // localhost/api/employees [resource]
        public List<Employee> GetAllEmployees()
        {
            _logger.LogInformation("GetAllEmployees has been called.");
            return employeeRepository.EmployeeList;
        }

        [HttpGet("{id:int}")]
        public Employee GetOneEmployee(int id)
        {
            _logger.LogInformation($"GetOneEmployee with {id} has been called.");
            return employeeRepository.GetOne(id);
        }


        [HttpPost] // localhost/api/employees [resource]
        public void CreateOneEmployee(Employee employee)
        {
            _logger.LogInformation($"CreateOneEmployee has been called.");
            employeeRepository.Add(employee);
        }

        [HttpPut("{id:int}")] // localhost/api/employees/{id} [resource]
        public void UpdateOneEmployee(int id, Employee employee)
        {
            _logger.LogInformation($"UpdateOneEmployee with {id} has been called.");
        }

        [HttpDelete("{id:int}")] // localhost/api/employees/{id} [resource]
        public void DeleteOneEmployee(int id, Employee employee)
        {
            _logger.LogInformation($"DeleteOneEmployee with {id} has been called.");
            
        }
    }
}