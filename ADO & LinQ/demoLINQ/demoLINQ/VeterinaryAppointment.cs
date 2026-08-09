using System;
using System.Collections.Generic;
using System.Text;

namespace demoLINQ
{
    public class VeterinaryAppointment
    {
        public DateTime Date { get; set; }
        public int AnimalID { get; set; }

        public VeterinaryAppointment(DateTime date, int animalID)
        {
            Date = date;
            AnimalID = animalID;
        }
    }
}
