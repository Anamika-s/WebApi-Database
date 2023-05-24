using WebApi_Database.Context;
using WebApi_Database.IRepo;
using WebApi_Database.Models;

namespace WebApi_Database.Repo
{
    public class StudentRepo : IStudentRepo
    {
        StudentDbContext _context;
        public StudentRepo(StudentDbContext context)
        {
            _context = context;
        }
        public void AddStudent(Student student)
        {
           _context.Students.Add(student);
            _context.SaveChanges();
        }

        public void DeleteStudent(int id)
        {
          Student student = _context.Students.FirstOrDefault(
              x => x.Id == id);
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
        }

        public void EditStudent(int id, Student student)
        {
           
        }
        public Student GetStudentById(int id)
        {
            Student student = _context.Students.FirstOrDefault(
              x => x.Id == id);
            return student;
        }
        public List<Student> GetStudents()
        {
                return _context.Students.ToList();

            }
    }
}
