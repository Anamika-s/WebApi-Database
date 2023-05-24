using WebApi_Database.Models;

namespace WebApi_Database.IRepo
{
    public interface IStudentRepo
    {
        public List<Student> GetStudents();
        public Student GetStudentById(int id);
        public void AddStudent(Student student);
        public void EditStudent(int id, Student student);
        public void DeleteStudent(int id);


    }

}
