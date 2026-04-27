using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Clinic_Appointment_System.Entities
{
    internal class Appointment
    {
        public int Id { get;}
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        public DateTime DateTime { get; set; }

        private static int Counter = 0;
        public Appointment(Doctor doctor, Patient patient, DateTime date)
        {
            Counter++;
            Id = Counter;
            Doctor = doctor;
            Patient = patient;
            DateTime = date;
        }

        override public string ToString()
        {
            return $"Appointment ID: {Id}, Patient: [{Patient}], Doctor: [{Doctor}], Date and Time: {DateTime}";
        }

    }
}
