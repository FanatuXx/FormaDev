using AuthSecurity.Models;

namespace AuthSecurity.Infrastructure
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}