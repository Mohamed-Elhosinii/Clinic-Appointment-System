using Clinic_Appointment_System.Entities;
using Clinic_Appointment_System.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic_Appointment_System.Services
{
    internal class DoctorServices : IDoctorService
    {
        private List<Doctor> Doctors;

        public DoctorServices()
        {
            Doctors = new List<Doctor>();
        }

        public void AddDoctor(Doctor doctor)
        {
            if (doctor == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: Cannot add a null doctor.");
                Console.ResetColor();
                return;
            }
            bool exists = false;
            foreach (var d in Doctors)
            {
                if (d.Name.Equals(doctor.Name, StringComparison.OrdinalIgnoreCase)
                    && d.Specialty.Equals(doctor.Specialty, StringComparison.OrdinalIgnoreCase))
                {
                    exists = true;
                    break;
                }
            }
            if (exists)
            {
                Console.WriteLine($"Dr. {doctor.Name} already exists in the system.");
            }
            else
            {
                Doctors.Add(doctor);
                Console.WriteLine($"Success: Dr. {doctor.Name} added.");
            }
        }

        public void RemoveDoctor(string Name, string Specialty)
        {
            if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Specialty))
            {
                Console.WriteLine("Error: Name and Specialty cannot be empty.");
                return;
            }
            else if (Doctors.Count == 0)
            {
                Console.WriteLine("No doctors available in the system.");
                return;
            }

            Doctor doctorToDelete = Doctors.Find(d => d.Name.Equals(Name, StringComparison.OrdinalIgnoreCase) && d.Specialty.Equals(Specialty, StringComparison.OrdinalIgnoreCase));

            if (doctorToDelete != null)
            {
                Doctors.Remove(doctorToDelete);
                Console.WriteLine($"Success: Doctor {doctorToDelete.Name} has been removed.");
            }
            else
            {
                Console.WriteLine("Error: Doctor not found with this Name and Specialty.");
            }
        }

        public void UpdateDoctor(string oldName, string oldSpecialty, string newName, string newSpecialty, decimal newPrice)
        {
            if (string.IsNullOrWhiteSpace(oldName) || string.IsNullOrWhiteSpace(oldSpecialty))
            {
                Console.WriteLine("Error: You must provide current Name and Specialty.");
                return;
            }

            Doctor docToUpdate = Doctors.Find(d => d.Name.Equals(oldName, StringComparison.OrdinalIgnoreCase) && d.Specialty.Equals(oldSpecialty, StringComparison.OrdinalIgnoreCase));

            if (docToUpdate == null)
            {
                Console.WriteLine($"Error: Doctor '{oldName}' with specialty '{oldSpecialty}' not found.");
                return;
            }
            string backupName = docToUpdate.Name;
            string backupSpecialty = docToUpdate.Specialty;
            decimal backupPrice = docToUpdate.Price;

            try
            {
                docToUpdate.Name = newName;
                docToUpdate.Specialty = newSpecialty;
                docToUpdate.Price = newPrice;
                Console.WriteLine("Success: Doctor updated successfully.");
            }
            catch (Exception ex)
            {
                docToUpdate.Name = backupName;
                docToUpdate.Specialty = backupSpecialty;
                docToUpdate.Price = backupPrice;
                Console.WriteLine("Update Failed! Reverting changes...");
                Console.WriteLine($"Reason: {ex.Message}");
            }
        }

        public void ViewDoctors()
        {
            if (Doctors.Count == 0)
            {
                Console.WriteLine("No doctors registered yet.");
            }
            else
            {
                foreach (var doc in Doctors)
                {
                    Console.WriteLine(doc);
                }
            }
        }

        public Doctor GetDoctorByNameAndSpecialty(string name, string specialty)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(specialty))
                return null;

            return Doctors.Find(d => d.Name.Equals(name, StringComparison.OrdinalIgnoreCase)
                                     && d.Specialty.Equals(specialty, StringComparison.OrdinalIgnoreCase));
        }

        public List<Doctor> GetDoctorsList()
        {
            return Doctors;
        }

    }
}
