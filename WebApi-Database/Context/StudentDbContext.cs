using Microsoft.EntityFrameworkCore;
using WebApi_Database.Models;

namespace WebApi_Database.Context
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext()
        {

        }
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {

        }
        public DbSet<Student>   Students{ get; set; }
    }
}
