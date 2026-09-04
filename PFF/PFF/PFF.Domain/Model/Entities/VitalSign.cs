using System;
using System.Collections.Generic;
using System.Text;

namespace PFF.Domain.Model.Entities
{
    public class VitalSign
    {
        public int Id { get; set; }
        public int HeartRate { get; set; }
        public string BloodPressure { get; set; }
        public decimal Temperature { get; set; }
        public int RespiratoryRate { get; set; }
        public int OxygenSaturation { get; set; }
        public int ConsultationId { get; set; }
        public virtual Consultation Consultation { get; set; }
    }
}
