using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_Database.IRepo;
using WebApi_Database.Models;

namespace WebApi_Database.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StudentController : ControllerBase
    {
        IStudentRepo _repo;
        public StudentController(IStudentRepo repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public List<Student> GetStudents()
        {
            return _repo.GetStudents();
        }

        [HttpGet("{id}")]

        public Student GetStudentById(int id)
        {
            return _repo.GetStudentById(id);
        }


        [HttpPost]
        public void AddStudent(Student student)
        {
            _repo.AddStudent(student);
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
