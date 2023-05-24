using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_Database.IRepo;
using WebApi_Database.Models;

namespace WebApi_Database.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Student2Controller : ControllerBase
    {
        IStudentRepo _repo;
        public Student2Controller(IStudentRepo repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public ActionResult <List<Student>> GetStudents()
        {
            if (_repo.GetStudents().ToList().Count == 0)
                return NotFound();
            else

                return _repo.GetStudents();
        }

        [HttpGet("{id}")]

        public ActionResult<int>GetStudentById(int id)
        {
            if (_repo.GetStudentById(id) == null)
                return 0;
            else
                return Ok(_repo.GetStudentById(id));
        } 

        [HttpPost]
        public ActionResult<int> AddStudent(Student student)
        {
            _repo.AddStudent(student);
          return Created("Created", student);
        }

        [HttpPut("{id}")]
        public void UpdateStudent(int id, Student student) {
            _repo.EditStudent(id, student);

        }
        [HttpDelete("{id}")]

        public ActionResult<string> DeleteStudent(int id)
        {
            Student student = _repo.GetStudentById(id);
            if (student == null)
                return "There is no record";
            else
            {

                _repo.DeleteStudent(id);
                return Ok("Record deleted");
            }
        }


    }
}
