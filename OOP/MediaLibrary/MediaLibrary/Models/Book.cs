using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Book : Media
    {
        //PROPRIETES
        public string Author { get; private set; }



        //OVERRIDE FONCTION MERE
        public override int LoanDurationDays()
        {
            return 21;
        }



        //CONSTRUCTEURS
        public Book(string isbn, string title, string author) : base(isbn, title)
        {
            Author = author;
        }

        public Book(string isbn, string title, string author, bool isAvailable) : base(isbn, title, isAvailable)
        {
            Author = author;
        }

    }
}
