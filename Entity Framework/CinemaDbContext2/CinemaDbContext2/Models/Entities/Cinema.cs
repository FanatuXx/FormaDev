using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaDbContext2.Models.Entities
{
    public class Cinema
    {
        public int Id { get; set; }
        public string Nom { get; set; } = null!;
        public string Adresse { get; set; } = string.Empty;
        public string Ville { get; set; } = string.Empty;

        public ICollection<Salle> Salles { get; set; } = new List<Salle>();
        public ICollection<Film> Films { get; set; } = new List<Film>();
    }
}
