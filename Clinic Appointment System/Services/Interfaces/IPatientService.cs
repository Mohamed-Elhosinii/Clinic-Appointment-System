using Clinic_Appointment_System.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic_Appointment_System.Services.Interfaces
{
    public interface IPatientService
    {
        void AddPatient(Patient patient);
        void DeletePatient(string phone);
        void UpdatePatient(string phone, string newName, string newEmail);
        void ViewPatients();
    }
}
