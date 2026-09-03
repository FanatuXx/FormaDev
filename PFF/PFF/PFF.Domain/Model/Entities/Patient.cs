using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PFF.Domain.Model.Entities
{
    public class Patient
    {
        public int Id { get; set; }
        public int SSIN { get; set; }
        public string FirstName { get; set; } 
        public string LastName { get; set; } 
        public string Alias { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public int PhoneNumber { get; set; }
        public DateTime RegistrationDate { get; set; } = DateTime.Now;
        public DateTime LastVisit { get; set; }
        public int PatientAddressId { get; set; }
        public PatientAddress PatientAddress { get; set; }
        public virtual IList<Prescription> Prescriptions { get; set; } = new List<Prescription>();
        public virtual IList<Consultation> Consultations { get; set; } = new List<Consultation>();
    }
}
