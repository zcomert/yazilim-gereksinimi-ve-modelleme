using Microsoft.AspNetCore.Mvc;
using StudentApp.Models;

namespace StudentApp.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        public Student[] StudentList { get; set; }
        public StudentsController()
        {
            StudentList = new Student[4];
            StudentList[0] = new Student()
            {
                Number = 112,
                FirstName = "Hafza",
                LastName = "Çataklı"
            };

            var student2 = new Student();
            student2.Number = 118;
            student2.FirstName = "Gülbin";
            student2.LastName = "Beydilli";

            StudentList[1] = student2;
            StudentList[2] = new Student()
            {
                Number = 110,
                FirstName = "Berat",
                LastName = "Güngör"
            };
            StudentList[3] = new Student()
            {
                Number = 911,
                FirstName = "Celal",
                LastName = "Halilov"
            };
        }

        [HttpGet] // localhost/api/students
        public Student[] GetAllStudents()
        {
            return StudentList;
        }

        [HttpGet("{id}")] // localhost/api/students/{id}
        public Student GetOneStudent(int id)
        {
            if(id <0 || id>=StudentList.Length)
            {
                // return new Student();
                throw new ArgumentOutOfRangeException($"parameter must be 0 or {StudentList.Length-1}.");
            }
            return StudentList[id];
        }

    }
}