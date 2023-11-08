using ErrorHandleApp.Models;
using ErrorHandleApp.Models.Exceptions;

namespace ErrorHandleApp.Repositories;
public class EmployeeRepository
{
    private List<Employee> _employees;
    public EmployeeRepository()
    {
        _employees = new List<Employee>(){
            new FullTimeEmployee(1,"Ahmet","Can",50_000),
            new FullTimeEmployee(2,"Filiz","Dağ",40_000),
            new SeasonalEmployee(3,"Meryem","Ak",35_000),
            new SeasonalEmployee(3,"Can","Kara",75_000),
        };
    }

    public void Add(Employee item)
    {
        _employees.Add(item);
    }

    public List<Employee> GetAllEmployees()
    {
        return _employees;
    }

    public Employee GetOneEmployee(int id)
    {
        var employee = _employees.Single(e => e.Id.Equals(id));

        if (employee is null)
            throw new EmployeeNotFoundException(id);

        return employee;
    }
}