using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaDbContext2.Models.Entities
{
    public class Film
    {
        public int Id { get; set; }
        public string Titre { get; set; } = null!;
        public int DureeMinutes { get; set; }
        public bool Est3D { get; set; }
        public int PrixTicket { get; set; }

        public ICollection<Cinema> Cinemas { get; set; } = new List<Cinema>();

    }
}
