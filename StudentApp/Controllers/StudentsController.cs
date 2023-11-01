using Microsoft.AspNetCore.Mvc;
using StudentApp.Models;

namespace StudentApp.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {
        private readonly ILogger<StudentsController> _logger;
        private readonly StudentRepository studentRepository;

        public StudentsController(ILogger<StudentsController> logger, StudentRepository studentRepository)
        {
            _logger = logger;
            this.studentRepository = studentRepository;
        }

        [HttpGet] // localhost/api/students
        public IActionResult GetAllStudents()
        {
            _logger.LogInformation("GetAllStudents has been called.");
            return Ok(studentRepository.GetAllStudent());
        }

        [HttpGet("{id}")] // localhost/api/students/{id}
        public IActionResult GetOneStudent(int id)
        {
            _logger.LogInformation($"GetOneStudent with id : {id} has been called.");
            var result = studentRepository.GetOneStudent(id);
            return result != null ? Ok(result) : NotFound();
        }

        [HttpPost]
        public Student CreateOneStudent(Student student)
        {
            _logger.LogInformation($"CreateOneStudent has been called.");
            return studentRepository.CreateOneStudent(student);
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateOneStudent(int id, Student student)
        {
            _logger.LogInformation($"UpdateOneStudent with id : {id} has been called.");
            studentRepository.UpdateOneStudent(id, student);
            return GetOneStudent(id);
        }

        [HttpDelete("{id:int}")]
        public void DeleteOneStudent(int id)
        {
            //
            _logger.LogInformation($"DeleteOneStudent with id : {id} has been called.");
            studentRepository.DeleteOneStudent(id);
        }
    }
}