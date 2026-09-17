using System.ComponentModel.DataAnnotations;

namespace AuthSecurity.Models.Dtos
{
    public class RefreshTokenDto
    {
        [Required]
        public string RefreshToken { get; set; } = default!;
        [Required]
        public string Token { get; set; } = default!;
    }
}
