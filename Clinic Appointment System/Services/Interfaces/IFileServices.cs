using Clinic_Appointment_System.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic_Appointment_System.Services.Interfaces
{
    internal interface IFileServices
    {
        public void SaveAllAndClear(List<Doctor> doctors, List<Patient> patients, List<Payment> payments, List<Appointment> appointments, string filePath);
    }
}

