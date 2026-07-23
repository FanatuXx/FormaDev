using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Book : Media
    {
        public string Author { get; set; }

        public override int LoanDurationDays()
        {
            return 21;
        }

        public Book(string isbn, string title, bool isAvailable) : base(isbn, title, isAvailable)
        {
        }

        public Book(string isbn, string title) : base(isbn, title)
        {
        }
    }
}
