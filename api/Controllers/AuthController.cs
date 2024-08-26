using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using contacts2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace contacts2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginPayload login)
        {
            UserDto? user = null;
            if (login.Username == "omurillob@gmail.com" && login.Password == "1234")
            {
                user = new UserDto
                {
                    Id = 1,
                    Username = "omurillob@gmail.com"
                };
            }

            if (user == null)
            {
                return BadRequest("Invalid username or password");
            }

            var tokenString = GenerateJwtToken(user);

            return Ok(new { token = tokenString });
        }

        private string GenerateJwtToken(UserDto user)
        {
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"] ?? string.Empty);
            var securityKey = new SymmetricSecurityKey(key);
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
            };

            var token = new JwtSecurityToken(
              issuer: _configuration["Jwt:Issuer"],
              audience: _configuration["Jwt:Audience"],
              claims: claims,
              expires: DateTime.Now.AddMinutes(30),
              signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}