using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using WebApi_Database.Models;
using WebApi_Database.Context;
using System.Security.Claims;

namespace WebApi_Database.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        StudentDbContext _context;
        IConfiguration _config;
        public LoginController(StudentDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }
        [HttpPost]
        public IActionResult Login(User User)
        {
            IActionResult response = Unauthorized();
            var user = Authenticate(User);
            if (user != null)
            {
                var tokenString = 
                    GenerateJSONWebToken(user.Id, user.Password, user.RoleId);
                response = Ok(new { token = tokenString });
            }
            return response;
        }
        private string GenerateJSONWebToken(int Id, string password, int role)
        {
            Claim[] claims = new[]
         {
                 new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                 new Claim(JwtRegisteredClaimNames.Sid, Id.ToString()),
                 new Claim(JwtRegisteredClaimNames.Email, password),
                 new Claim(ClaimTypes.Role, role.ToString()),
                 new Claim(type:"Date", DateTime.Now.ToString())
            };
            var securityKey = new
            SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
           
            var credentials = new SigningCredentials(securityKey,
            SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
           _config["Jwt:Issuer"],
            claims,
expires: DateTime.Now.AddMinutes(120),
signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public User Authenticate(User user)
        {
            User obj = _context.Users.FirstOrDefault(x => x.UserName == user.UserName
            && x.Password == user.Password);
             
            return obj;
        }
    }

}