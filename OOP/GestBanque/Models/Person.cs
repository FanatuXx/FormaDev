using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Person
    {
        public string Surname { get; set; }
        public string Firstname { get; set; }

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
}
