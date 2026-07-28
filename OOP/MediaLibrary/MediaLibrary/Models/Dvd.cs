using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Dvd : Media
    {
        //PROPRIETES
        public string Director { get; private set; }

        private int _durationMinutes;
        public int DurationMinutes 
        {
            get
            {
                return _durationMinutes;
            }
            
            private set
            {
                if (!(value > 0))
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "La durée d'un film ne peut pas être inférieure à 1 minute.");  //nameOf(value) permet d'afficher la variable qui pose problème
                }
                _durationMinutes = value;
            }
        }


        //FONCTIONS
        public override int LoanDurationDays()
        {
            return DurationMinutes < 90 ? 7 : 3;
        }


        //CONSTRUCTEURS
        public Dvd(string isbn, string title, string director, int durationMinutes) : base(isbn, title)                                 //Etant donné que les mutateurs sont private (holder, durationMinutes), elles DOIVENT être incluses dans le constructeurs !!!
        {
            Director = director;
            DurationMinutes = durationMinutes;
        }

        public Dvd(string isbn, string title, string director, int durationMinutes, bool isAvailable) : base(isbn, title, isAvailable)
        {
            Director = director;
            DurationMinutes = durationMinutes;
        }
    }
}
