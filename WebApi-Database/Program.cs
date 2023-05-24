using Microsoft.EntityFrameworkCore;
using WebApi_Database.Context;
using WebApi_Database.IRepo;
using WebApi_Database.Repo;

namespace WebApi_Database
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "Dummy Web Api",
                    Description = "Its a dummy web api"
                });
            });
            builder.Services.AddControllers();
            builder.Services.AddDbContext<StudentDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection"));


            });
            builder.Services.AddTransient<IStudentRepo, StudentRepo>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseAuthorization();
            
            
            app.MapControllers();

            app.Run();
        }
    }
}