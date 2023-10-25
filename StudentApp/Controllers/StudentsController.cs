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
        public List<Student> GetAllStudents()
        {
            _logger.LogInformation("GetAllStudents has been called.");
            return studentRepository.GetAll();
        }

        [HttpGet("{id}")] // localhost/api/students/{id}
        public Student GetOneStudent(int id)
        {
            _logger.LogInformation($"GetOneStudent with id : {id} has been called.");
            return studentRepository.GetOne(id);
        }

        [HttpPost]
        public Student CreateOneStudent(Student student)
        {
            _logger.LogInformation($"CreateOneStudent has been called.");
            return studentRepository.CreateOne(student);
        }

        [HttpPut("{id:int}")]
        public Student UpdateOneStudent(int id, Student student)
        {
            _logger.LogInformation($"UpdateOneStudent with id : {id} has been called.");
            studentRepository.UpdateOne(id,student);
            return GetOneStudent(id);
        }

        [HttpDelete("{id:int}")]
        public void DeleteOneStudent(int id)
        {
            //
            _logger.LogInformation($"DeleteOneStudent with id : {id} has been called.");
            studentRepository.DeleteOne(id);
        }
    }
}