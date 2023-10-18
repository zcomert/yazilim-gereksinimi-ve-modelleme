using Microsoft.AspNetCore.Server.IIS.Core;

namespace EmployeeApp.Models
{
    public static class EmployeeRepository
    {
        public static List<Employee> EmployeeList { get; set; }
        static EmployeeRepository()
        {
            EmployeeList = new List<Employee>();
            EmployeeList.Add(new Employee(){Id=1, FirstName="Ahmet",LastName="Güneş"});
            EmployeeList.Add(new Employee(){Id=2, FirstName="Can",LastName="Dağ"});
            EmployeeList.Add(new Employee(){Id=3, FirstName="Merve",LastName="Yıldız"});
        }

        public static Employee GetOne(int id)
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

        public static void Add(Employee employee)
        {
            EmployeeList.Add(employee);
        }
    }
}