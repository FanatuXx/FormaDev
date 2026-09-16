using System.ComponentModel.DataAnnotations;

namespace AuthSecurity.Models.Dtos
{
    public class LoginDto
    {
        [EmailAddress]
        public string Email { get; set; } = default!;
    }
}
