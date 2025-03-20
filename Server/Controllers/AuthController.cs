using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ClinicManagementSystem.Server.Data;
using ClinicManagementSystem.Server.Models;

namespace ClinicManagementSystem.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        //[HttpPost("login")]
        //public IActionResult Login([FromBody] LoginRequest loginRequest)
        //{
        //    if (loginRequest == null || string.IsNullOrEmpty(loginRequest.Username) || string.IsNullOrEmpty(loginRequest.Password))
        //    {
        //        return BadRequest("Invalid login request.");
        //    }

        //    // Check if the user exists in the Admin table
        //    var admin = _context.Admins.FirstOrDefault(a => a.Username == loginRequest.Username && a.Password == loginRequest.Password);
        //    if (admin != null)
        //    {
        //        var token = GenerateJwtToken(admin.Username, "Admin");
        //        return Ok(new { Token = token, Role = "Admin" });
        //    }

        //    // Check if the user exists in the Receptionist table
        //    var receptionist = _context.Receptionists.FirstOrDefault(r => r.Name == loginRequest.Username && r.ClinicId != null);
        //    if (receptionist != null)
        //    {
        //        var token = GenerateJwtToken(receptionist.Name, "Receptionist");
        //        return Ok(new { Token = token, Role = "Receptionist" });
        //    }

        //    // Check if the user exists in the Doctor table
        //    var doctor = _context.Doctors.FirstOrDefault(d => d.Name == loginRequest.Username && d.ClinicId != null);
        //    if (doctor != null)
        //    {
        //        var token = GenerateJwtToken(doctor.Name, "Doctor");
        //        return Ok(new { Token = token, Role = "Doctor" });
        //    }

        //    return Unauthorized("Invalid username or password.");
        //}


        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest loginRequest)
        {
            // Validate user credentials (replace with database validation)
            if (loginRequest.Username == "admin" && loginRequest.Password == "admin123")
            {
                var token = GenerateJwtToken(loginRequest.Username, "Admin");
                return Ok(new { Token = token });
            }

            return Unauthorized("Invalid username or password.");
        }

        private string GenerateJwtToken(string username, string role)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.Role, role)
        };

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }

    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}