using Clinic_Appointment_System.Entities;
using Clinic_Appointment_System.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Clinic_Appointment_System.Services
{
    internal class FileService : IFileServices
    {
        public void SaveAllAndClear( List<Doctor> doctors,List<Patient> patients , List<Payment> payments, List<Appointment> appointments ,string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("filePath is required", nameof(filePath));

            var dir = Path.GetDirectoryName(filePath);

            if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
                Directory.CreateDirectory(dir);



            using (var writer = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                writer.WriteLine("=== Doctors ===");
                if (doctors == null || doctors.Count == 0)
                {
                    writer.WriteLine("[No doctors]");
                }
                else
                {
                    foreach (var d in doctors)
                        writer.WriteLine(d?.ToString() ?? string.Empty);
                }

                writer.WriteLine();


                writer.WriteLine("=== Patients ===");
                if (patients == null || patients.Count == 0)
                {
                    writer.WriteLine("[No patients]");
                }
                else
                {
                    foreach (var p in patients)
                        writer.WriteLine(p?.ToString() ?? string.Empty);
                }

                writer.WriteLine();


                writer.WriteLine("=== Payments ===");
                if (payments == null || payments.Count == 0)
                {
                    writer.WriteLine("[No payments]");
                }
                else
                {
                    foreach (var pay in payments)
                        writer.WriteLine(pay?.ToString() ?? string.Empty);
                }

                writer.WriteLine();


                writer.WriteLine("=== Appointments ===");
                if (appointments == null || appointments.Count == 0)
                {
                    writer.WriteLine("[No appointments]");
                }
                else
                {
                    foreach (var ap in appointments)
                        writer.WriteLine(ap?.ToString() ?? string.Empty);
                }
            }

          
            doctors?.Clear();
            patients?.Clear();
            payments?.Clear();
            appointments?.Clear();
        }
    }
}
