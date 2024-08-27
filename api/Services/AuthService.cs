using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using contacts2.Models;
using Microsoft.IdentityModel.Tokens;
using contacts2.Controllers;

namespace contacts2.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public User? AuthenticateUser(string username, string password)
        {
            if (username == "omurillob@gmail.com" && password == "1234")
            {
                return new User
                {
                    Id = 1,
                    Username = "omurillob@gmail.com"
                };
            }
            return null;
        }

        public string GenerateJwtToken(User user)
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