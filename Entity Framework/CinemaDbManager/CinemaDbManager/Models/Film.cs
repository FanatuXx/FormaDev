using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaDbManager.Models
{
    public class Film
    {
        public int Id { get; set; }
        public string Titre { get; set; } = null!;
        public int DureeMinutes { get; set; }
        public bool Est3D { get; set; }
        public int PrixTicket { get; set; }
    }
}
