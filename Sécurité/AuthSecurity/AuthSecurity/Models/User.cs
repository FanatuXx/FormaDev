namespace AuthSecurity.Models
{
    public class User(int id, string nom, string prenom, string email, string role)
    {
        public int Id { get; set; } = id;
        public string Nom { get; set; } = nom;
        public string Prenom { get; set; } = prenom;
        public string Email { get; set; } = email;
        public string Role { get; set; } = role;
        public string? RefreshToken { get; set; }
    }
}
