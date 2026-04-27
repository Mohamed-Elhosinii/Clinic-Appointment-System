using Clinic_Appointment_System.Entities;
using Clinic_Appointment_System.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic_Appointment_System.Services
{
    public class PatientService : IPatientService
    {
        private List<Patient> Patients;

        public PatientService()
        {
            Patients=new List<Patient>();
        }

        public void AddPatient(Patient patient)
        {
            if (patient == null)
            {
                Console.WriteLine("patient is null");
                return;
            }

            foreach (var p in Patients)
            {
                if (p.Phone == patient.Phone)
                {
                    Console.WriteLine("this Phone Already exists");
                    return;

                }
                else if (p.Email == patient.Email)
                {
                    Console.WriteLine("this Email Already exists");
                    return;

                }
            }

            Patients.Add(patient);

        }

        public void DeletePatient(string phone)
        {
            var DeletedPatient = GetPatientByPhone(phone);

            if (DeletedPatient == null)
            {
                Console.WriteLine("patient not exist");
            }
            else
            {
                Patients.Remove(DeletedPatient);
                Console.WriteLine("patient Deleted");
            }
        }

        public void ViewPatients()
        {
            if (Patients.Count == 0)
            {
                Console.WriteLine("No Data");
                return;
            }
            foreach (var x in Patients)
            {
                Console.WriteLine($"Id: {x.Id} Name: {x.Name} Phone: {x.Phone} Email: {x.Email}");
            }
        }

        public void UpdatePatient(string phone, string Newname, string Newemail)
        {
            var UpdatedPatient = GetPatientByPhone(phone);

            if (UpdatedPatient == null)
            {
                Console.WriteLine("patient not exist");
                return;
            }

            // Trim inputs
            Newname = Newname?.Trim();
            Newemail = Newemail?.Trim();

            // Check for email duplicate 
            foreach (var p in Patients)
            {
                if (p.Id != UpdatedPatient.Id && string.Equals(p.Email, Newemail, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("this Email Already exists");
                    return;
                }
            }

            UpdatedPatient.Name = Newname;
            UpdatedPatient.Email = Newemail;
        }

        public Patient GetPatientByPhone(string phone)
        {
            foreach (var patient in Patients)
            {
                if (patient.Phone == phone)
                {
                    return patient;
                }


            }
            return null;
        }

        public List<Patient> GetPatientsList()
        {
            return Patients;
        }

    }
}
