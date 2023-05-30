using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using WebApi_Database.Models;
using WebApi_Database.Context;

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
                var tokenString = GenerateJSONWebToken(user);
                response = Ok(new { token = tokenString });
            }
            return response;
        }
        private string GenerateJSONWebToken(User user)
        {
            var securityKey = new
            SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey,
            SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
_config["Jwt:Issuer"],
null,
expires: DateTime.Now.AddMinutes(120),
signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public User Authenticate(User user)
        {
            User obj = _context.Users.FirstOrDefault(x => x.UserName == user.UserName
            && x.Password == user.Password);
            return user;
        }
    }

}