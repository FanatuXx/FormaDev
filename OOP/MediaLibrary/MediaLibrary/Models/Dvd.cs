using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Dvd : Media
    {
        private string Director { get; set; }
        private int DurationMinutes { get; set; }

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
