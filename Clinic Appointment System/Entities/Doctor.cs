using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic_Appointment_System.Entities
{
    public class Doctor
    {
      
        private static int counter = 0;
        private int id;
        private string name;
        private decimal price;
        private string specialty;
      

        public Doctor(string _name, decimal _price, string _specialty)
        {
            id = counter++;
            Name = _name;
            Price = _price;
            Specialty = _specialty;
        }

        public int Id
        {
            get { return id; }
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("Name cannot be empty or whitespace.");
                else if (value.Length < 3)
                    throw new Exception("Error: Name must be at least 3 chars.");
                else
                    name = value;
            }
        }
        public decimal Price
        {
            get { return price; }
            set
            {
                if (value < 0)
                    throw new Exception("Error: Price cannot be negative.");
                else
                    price = value;
            }
        }
        public string Specialty
        {
            get { return specialty; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("Error: Specialty cannot be empty.");
                else
                    specialty = value;
            }
        }
      


        override public string ToString()
        {
            return $"Doctor ID : {Id} Doctor Name: {Name}, Specialty: {Specialty}, Consultation Price: {Price} EGP";
        }
    }
}
