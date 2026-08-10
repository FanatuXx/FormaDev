using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaDbManager.Models
{
    public class Salle
    {
        public int Id { get; set; }
        public string Numero { get; set; } = null!;
        public int NombrePlaces { get; set; }
        public bool Est3D { get; set; }
        public int CinemaId { get; set; }

        public Cinema Cinema { get; set; } = null!;
    }
}
