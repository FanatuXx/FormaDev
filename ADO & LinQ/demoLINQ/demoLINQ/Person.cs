using System;
using System.Collections.Generic;
using System.Text;

namespace demoLINQ
{
    public class Person
    {
        public int PersonID { get; set; }
        public string Name { get; set; }

        public Person (int personID, string name)
        {
            PersonID = personID;
            Name = name;
        }
    }
}
