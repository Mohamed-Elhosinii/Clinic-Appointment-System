using Clinic_Appointment_System.Entities;
using Clinic_Appointment_System.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic_Appointment_System.Services
{
    internal class AppointmentService : IAppointmentService
    {
        private List<Appointment> AppointmentList;
        public AppointmentService()
        {
            AppointmentList = new List<Appointment>();
        }

        public void AddAppointment(Patient patient, Doctor doctor, DateTime dateTime)
        {
            foreach (var appointment in AppointmentList)
            {
                if (appointment.Doctor == doctor && appointment.DateTime == dateTime)
                {
                    throw new Exception("This doctor already has an appointment at this time.");
                }

            }
            AppointmentList.Add(new Appointment(doctor, patient, dateTime));
        }
            public void UpdateAppointment(
            Appointment appointment,
            Patient newPatient,Doctor newDoctor,DateTime newDateTime)
        {
            if (!AppointmentList.Contains(appointment))
                throw new Exception("Appointment not found.");

            foreach (var item in AppointmentList)
                if (item.Doctor == newDoctor && item.DateTime == newDateTime)
                {
                    throw new Exception("This doctor already has another appointment at this time.");

                }
            appointment.Patient = newPatient;
            appointment.Doctor = newDoctor;
            appointment.DateTime = newDateTime;
        }

        public void DeleteAppointment(Appointment appointment)
        {
            if (!AppointmentList.Remove(appointment))
                throw new Exception("Appointment not found.");
        }

        public Appointment GetAppointment(Doctor doctor, DateTime dateTime)
        {
            foreach (var ap in AppointmentList)
            {
                if (ap.Doctor == doctor && ap.DateTime == dateTime)
                    return ap;
            }
            return null;
        }

        public void ViewAppointments()
        {
            if (AppointmentList.Count == 0)
            {
                Console.WriteLine("No appointments scheduled.");
                return;
            }
            foreach (var ap in AppointmentList)
            {
                Console.WriteLine($"Doctor: {ap.Doctor.Name} ({ap.Doctor.Specialty}) | Patient: {ap.Patient.Name} | Date: {ap.DateTime}");
            }
        }

        public List<Appointment> GetAppointmentsList()
        {
            return AppointmentList;
        }
    }
}
