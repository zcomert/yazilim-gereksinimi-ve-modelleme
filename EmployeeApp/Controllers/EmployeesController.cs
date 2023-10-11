
using EmployeeApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApp.Controllers
{
    [ApiController]
    [Route("api/employees")]
    public class EmployeesController : ControllerBase
    {
        public Employee[] EmployeeList { get; set; }

        public EmployeesController()
        {
            EmployeeList = new Employee[4];
            EmployeeList[0] = new Employee()
            {
                Id = 1,
                FirstName = "Emine",
                LastName = "Turan",
                Company = "Samsun Universitesi"
            };

            Employee emp2 = new Employee();
            emp2.Id = 212;
            emp2.FirstName = "Seher";
            emp2.LastName = "Emir";
            emp2.Company = "Samsun Universitesi";

            EmployeeList[1] = emp2;
            
            EmployeeList[2] = new Employee()
            {
                Id = 101,
                FirstName = "Abdullah",
                LastName = "Kapusuz",
                Company = "Samsun Universitesi"
            };

            EmployeeList[3] = new Employee()
            {
                Id = 301,
                FirstName = "Cemile",
                LastName = "Tanrıseven",
                Company = "Samsun Universitesi"
            };
        }

        [HttpGet] // localhost/api/employees [resource]
        public Employee[] GetAllEmployees()
        {
            return EmployeeList;
        }
    }
}