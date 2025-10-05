using Assignment2.Data;
using Assignment2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Assignment2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        
        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("/login")]
        public ActionResult Login([FromBody] LoginRequest request)
        {
            /* Search the Users table using the given lamda and return the first matching record */
            var user = _context.Users.FirstOrDefault(u => u.Username == request.Username && u.Password == request.Password);
            if(user == null)
            {
                return Unauthorized("Invalid username or password.");
            }
            var token = GenerateToken(user);
            return Ok(new { token });
        }

        /* Generate and return JWT */
        private string GenerateToken(User user)
        {
            /* 1. Define Claim instances (user info) */
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role)
            };
            /* 2. Create a symeetric security key using the given string */
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("i_am_doing_assignment_2_for_enterprise_class_hehe"));
            /* 3. Define the signing credentials */
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            /* 4. Create the actual JWT token object */
            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: credentials
                );
            /* 5. Convert the JWT object into an encoded string */
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
