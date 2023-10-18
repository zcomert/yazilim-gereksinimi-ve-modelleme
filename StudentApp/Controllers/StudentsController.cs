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
        public Student[] GetAllStudents()
        {
            _logger.LogInformation("GetAllStudents has been called.");
            return null;
        }

        [HttpGet("{id}")] // localhost/api/students/{id}
        public Student GetOneStudent(int id)
        {

            _logger.LogInformation($"GetOneStudent with id : {id} has been called.");
            return null;
        }

        [HttpPost]
        public Student CreateOneStudent(Student stundent)
        {
            _logger.LogInformation($"CreateOneStudent has been called.");
            return null;
        }

        [HttpPut("{id:int}")]
        public Student UpdateOneStudent(int id, Student stundent)
        {
            _logger.LogInformation($"UpdateOneStudent with id : {id} has been called.");
            return null;
        }

        [HttpDelete]
        public void DeleteOneStudent(int id, Student stundent)
        {
            //
            _logger.LogInformation($"DeleteOneStudent with id : {id} has been called.");

        }
    }
}