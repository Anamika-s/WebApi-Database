using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_Database.IRepo;
using WebApi_Database.Models;

namespace WebApi_Database.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Student1Controller : ControllerBase
    {
        IStudentRepo _repo;
        public Student1Controller(IStudentRepo repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public IActionResult GetStudents()
        {
            if (_repo.GetStudents().ToList().Count == 0)
                return NotFound();
            else

                return Ok(_repo.GetStudents());
        }

        [HttpGet("{id}")]

        public IActionResult GetStudentById(int id)
        {
            if (_repo.GetStudentById(id) == null)
                return NotFound("There is no rec");
            else 
            return  Ok(_repo.GetStudentById(id));
        } 

        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            _repo.AddStudent(student);
          return Created("Created", student);
        }

        [HttpPut("{id}")]
        public void UpdateStudent(int id, Student student) {
            _repo.EditStudent(id, student);

        }
        [HttpDelete("{id}")]

        public int DeleteStudent(int id)
        {
            _repo.DeleteStudent(id);
            return 1;
        }


    }
}
