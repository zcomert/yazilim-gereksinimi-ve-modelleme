using Microsoft.AspNetCore.Mvc;
using StudentApp.Models;

namespace StudentApp.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private readonly ILogger<StudentsController> _logger;

        public StudentsController(ILogger<StudentsController> logger)
        {
            _logger = logger;
        }

        [HttpGet] // localhost/api/students
        public List<Student> GetAllStudents()
        {
            _logger.LogInformation("GetAllStudents has been called.");
            return StudentRepository.StudentList;
        }

        [HttpGet("{id}")] // localhost/api/students/{id}
        public Student GetOneStudent(int id)
        {
            _logger.LogInformation($"GetOneStudent with id : {id} has been called.");
            return StudentRepository.GetOne(id);
        }

        [HttpPost]
        public Student CreateOneStudent(Student student)
        {
            _logger.LogInformation($"CreateOneStudent has been called.");
            return StudentRepository.CreateOne(student);
        }

        [HttpPut("{id:int}")]
        public Student UpdateOneStudent(int id, Student student)
        {
            _logger.LogInformation($"UpdateOneStudent with id : {id} has been called.");
            StudentRepository.UpdateOne(id,student);
            return GetOneStudent(id);
        }

        [HttpDelete("{id:int}")]
        public void DeleteOneStudent(int id)
        {
            //
            _logger.LogInformation($"DeleteOneStudent with id : {id} has been called.");
            StudentRepository.DeleteOne(id);
        }
    }
}