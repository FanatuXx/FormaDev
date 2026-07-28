using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Subscriber
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime InscriptionDate { get; private set; }

        public Subscriber(string firstName, string lastName, DateTime inscriptionDate)                  //NE PAS OUBLIER DE RAJOUTER DES CONSTRUCTEUR QUAND ON PASSE LES MUTATEURS EN PRIVATE !!!!
        {
            FirstName = firstName;
            LastName = lastName;
            InscriptionDate = inscriptionDate;
        }
    }
}
