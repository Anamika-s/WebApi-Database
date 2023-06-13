using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.X86;
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
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<User>()
//            .HasData(new User
//            {
//                Id = 1,
//                UserName ="user1",
//Password = "user1",
//RoleId = 1,
//        },
//new User
//{
//Id = 2,
//UserName = "user2",
//Password = "user2",
//RoleId=2
//},
//new User
//{
//Id = 3,
//UserName = "user3",
//Password = "user3",
//RoleId=3
//}
//);
//}
    }
}
