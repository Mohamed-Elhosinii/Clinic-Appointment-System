using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Clinic_Appointment_System.Entities
{
    internal class Payment
    {
        public int Id { get; }

        public Patient Patient { get; }

        public decimal Amount { get; }

        public DateTime Date { get;}

        private static int Counter=0;

        public Payment(Patient patient , decimal amount ,DateTime date )
        {
            Counter++;
            Id = Counter;
            Patient = patient;
            Amount = amount;
            Date = date;
        }

        override public string ToString()
        {
            return $"Payment ID: {Id}, Patient: [{Patient}], Amount: {Amount}, Date: {Date}";
        }
    }
}
