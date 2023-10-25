using Microsoft.AspNetCore.Server.IIS.Core;

namespace EmployeeApp.Models
{
    public class EmployeeRepository
    {
        public List<Employee> EmployeeList { get; set; }
        public EmployeeRepository()
        {
            EmployeeList = new List<Employee>();
            EmployeeList.Add(new Employee(){Id=1, FirstName="Ahmet",LastName="Güneş"});
            EmployeeList.Add(new Employee(){Id=2, FirstName="Can",LastName="Dağ"});
            EmployeeList.Add(new Employee(){Id=3, FirstName="Merve",LastName="Yıldız"});
        }

        public Employee GetOne(int id)
        {
            foreach (var emp in EmployeeList)
            {
                if(emp.Id.Equals(id))
                {
                    return emp;
                }
            }
            throw new Exception("Not found!");
        }

        public void Add(Employee employee)
        {
            EmployeeList.Add(employee);
        }
    }
}