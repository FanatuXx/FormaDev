using System;
using System.Collections.Generic;
using System.Text;

namespace PFF.Domain.Model.Entities
{
    public class Praticioner
    {
        public int SSIN { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public int PhoneNumber { get; set; }
        public int AddressId { get; set; }
    }
}
