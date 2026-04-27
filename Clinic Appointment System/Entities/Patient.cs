using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clinic_Appointment_System.Entities
{
    public class Patient
    {
        public  int Id { get;}

        public string Name { get; set; }
        
        public string Phone { get; set; }

        public string Email { get; set; }

        private static int Counter = 0;

        public Patient(string name ,string phone ,string email)
        {
            Counter++;
            Id=Counter;
            Name = name;
            Phone = phone;
            Email = email;
            
        }

        override public string ToString()
        {
            return $"Patient ID: {Id}, Name: {Name}, Phone: {Phone}, Email: {Email}";
        }
    }
}
