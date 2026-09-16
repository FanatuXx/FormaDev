using AuthSecurity.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace AuthSecurity.Infrastructure
{
    public class TokenService : ITokenService
    {
        private const string _privateKey = "MaSuperCléPrivéeDeLaMortQuiTueOuPas!!!";

        public string GenerateToken(User user)
        {
            byte[] secretKey = Encoding.Default.GetBytes(_privateKey);
            SymmetricSecurityKey symmetricKey = new SymmetricSecurityKey(secretKey);

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Sid, user.Id.ToString()),
                new Claim(ClaimTypes.Name, $"{user.Prenom} {user.Nom}"),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)

            };

            JwtSecurityToken Token = new JwtSecurityToken(
                issuer: "https://localhost:7048", //Celui qui FOURNIT le Token
                audience: "https://localhost:7048", //Celui qui UTILISER le Token
                claims: claims, //Les infos sur lesquelles se base le Token
                signingCredentials: new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha256) //Signature ?
            );

            string token = new JwtSecurityTokenHandler().WriteToken(Token);

            return token;

        }
    }
}
