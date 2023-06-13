using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Net.Mime;
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
        [Authorize]
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
        public IActionResult Upload([FromForm]Student student)
        {
            string sFolderPath;
            sFolderPath = "C:/Documents";
            //string path = Path.Combine("~/C:/Documents");

            var file = Request.Form.Files[0];
            ////var folderName = Path.Combine("\\Documents");
            //var folderName = Path.Combine("\\Documents");
            Directory.CreateDirectory(sFolderPath + "\\user");
            var pathToSave = sFolderPath + "\\user";
            //var pathToSave = Path.Combine(Directory.GetCurrentDirectory() + folderName + "\\user");
            if (file.Length > 0)
            {
                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                var fullPath = Path.Combine(pathToSave, fileName);
                //var dbPath = Path.Combine(folderName, fileName);
                using (FileStream stream = new(fullPath,FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                return Ok();
            }
            else
                return BadRequest();

                

        }
        //[HttpPost]
        [Authorize(Roles="1")]
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
