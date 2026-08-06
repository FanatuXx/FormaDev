using System;
using System.Collections.Generic;
using System.Text;

namespace ADO_console.Model
{
    public class Client
    {
        string firstName;
        string lastName;
        DateTime birthDate;
        int yearResult;
        string sectionId;
        bool active;

        public Client(string firstName, string lastName, DateTime birthDate, int yearResult, string sectionId)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.birthDate = birthDate;
            this.yearResult = yearResult;
            this.sectionId = sectionId;
            this.active = true;
        }
        //Test
    }
}
