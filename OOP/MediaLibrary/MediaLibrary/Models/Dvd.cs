using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Dvd : Media
    {
        public string Director { get; private set; }

        private int durationMinutes;
        public int DurationMinutes {
            
            get
            {
                return durationMinutes;
            }
            
            private set
            {
                if (!(value > 0))
                {
                    throw new ArgumentOutOfRangeException("La durée d'un film ne peut pas être inférieure à 1 minute.");
                }
                durationMinutes = value;
            }
        }


        public override int LoanDurationDays()
        {
            if(DurationMinutes < 90)
            {
                return 7;
            }

            return 3;
        }

        public Dvd(string isbn, string title, bool isAvailable) : base(isbn, title, isAvailable)
        {
        }

        public Dvd(string isbn, string title) : base(isbn, title)
        {
        }

        public Dvd(string isbn, string title, string director, int duration) : this(isbn, title)
        {
            Director = director;
            DurationMinutes = duration;
        }

    }
}
