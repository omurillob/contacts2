using contacts2.Models;

namespace contacts2.Services
{
    public interface IAuthService
    {
        User? AuthenticateUser(string username, string password);
        string GenerateJwtToken(User user);
    }
}