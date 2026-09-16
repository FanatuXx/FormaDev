using AuthSecurity.Models;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using System.Text;

namespace AuthSecurity.Infrastructure
{
    public class TokenService
    {
        private const string _privateKey = "MaSuperCléPrivéeDeLaMortQuiTueOuPas!!!";

        public string GenerateToken(User user)
        {
            byte[] secretKey = Encoding.Default.GetBytes(_privateKey);
            SymmetricSecurityKey symmetricKey = new SymmetricSecurityKey(secretKey);

            //byte[] bytes = RandomNumberGenerator.GetBytes(256);

            string token = default!;
            return token;

        }
    }
}
