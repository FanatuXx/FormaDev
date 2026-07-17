using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Person
    {
        public string Surname { get; init; }
        public string Firstname { get; init; }

        private DateTime birthDate;
        public DateTime BirthDate {
            get
            {
                return birthDate;
            }
            set
            {
                DateTime today = DateTime.Now;
                //Check si la valeur rentrée n'est pas dans le futur OU + de 110ans dans le passé
                if (value <= today || value > today.AddYears(-110))
                {
                    birthDate = value;
                }
            }
        }

        public Person(string surname, string firstname, DateTime birthDate)
        {
            Surname = surname;
            Firstname = firstname;
            BirthDate = birthDate;
        }
    }
}
