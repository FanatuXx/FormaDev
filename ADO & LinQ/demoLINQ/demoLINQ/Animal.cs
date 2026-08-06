using System;
using System.Collections.Generic;
using System.Text;

namespace demoLINQ
{
    public class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NbPatte { get; set; }
        
        public Animal(int id, string name, int nbPatte)
        {
            Id = id;
            Name = name;
            NbPatte = nbPatte;
        }
    }
}
