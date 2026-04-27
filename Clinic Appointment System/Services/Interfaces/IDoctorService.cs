using Clinic_Appointment_System.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic_Appointment_System.Services.Interfaces
{
    public interface IDoctorService
    {
        void AddDoctor(Doctor doctor);
        void RemoveDoctor(string name, string specialty);
        void UpdateDoctor(string oldName, string oldSpecialty,string newName,string newSpecialty,decimal newPrice);

       void ViewDoctors();
    }
}
