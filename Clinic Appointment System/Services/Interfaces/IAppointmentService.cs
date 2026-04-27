using Clinic_Appointment_System.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic_Appointment_System.Services.Interfaces
{
    internal interface IAppointmentService
    {
        void AddAppointment(Patient patient, Doctor doctor, DateTime dateTime);

        void UpdateAppointment( Appointment appointment,Patient Patient ,Doctor Doctor, DateTime DateTime);

        void DeleteAppointment(Appointment appointment);
    }
}
