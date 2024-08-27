using contacts2.Models;
using contacts2.Services;
using Microsoft.AspNetCore.Mvc;

namespace contacts2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginPayload login)
        {
            User? user = authService.AuthenticateUser(login.Username, login.Password);

            if (user == null)
            {
                return BadRequest("Invalid username or password");
            }

            var tokenString = authService.GenerateJwtToken(user);

            return Ok(new { token = tokenString });
        }
    }
}