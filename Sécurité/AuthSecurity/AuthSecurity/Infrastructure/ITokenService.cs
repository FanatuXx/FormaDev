using AuthSecurity.Models;

namespace AuthSecurity.Infrastructure
{
    public interface ITokenService
    {
        string GenerateToken(User user);
        string GenerateRefreshToken();
        int GetUserIdFrom(string token);
    }
}