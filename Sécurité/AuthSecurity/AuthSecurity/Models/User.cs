namespace AuthSecurity.Models
{
    public class User
    {
        public User(int id, string nom, string prenom, string email, string role)
        {
            Id = id;
            Nom = nom;
            Prenom = prenom;
            Email = email;
            Role = role;
        }

        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
