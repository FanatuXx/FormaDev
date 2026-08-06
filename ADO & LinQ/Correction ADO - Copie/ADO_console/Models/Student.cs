using System;
using System.Collections.Generic;
using System.Text;

namespace ADO_console.Model
{
    public class Student
    {
        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int YearResult { get; set; }
        public int SectionID { get; set; }
        public bool Active { get; set; }

        public Student(int? id, string firstName, string lastName, DateTime birthDate, int yearResult, int sectionID, bool active)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            YearResult = yearResult;
            SectionID = sectionID;
            Active = active;
        }
        
    }
}
