using Clinic_Appointment_System.Entities;
using Clinic_Appointment_System.InputHandler;
using Clinic_Appointment_System.Services;
 
namespace Clinic_Appointment_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("--------- Clinic Appointment System ----------");
            Console.WriteLine("----------------------------------------------");

            PatientService patient = new PatientService();
            DoctorServices Doctor = new DoctorServices();
            AppointmentService appointmentService = new AppointmentService();
            PaymentService paymentService = new PaymentService();
            FileService fileService = new FileService();
            ConsoleKeyInfo keyInfo;

            while (true)
            {
                Console.WriteLine("\n--- Main Menu ---");
                Console.WriteLine("1. Clinic Manager");
                Console.WriteLine("2. Schedule Manager");
                Console.WriteLine("3. Payment Manager");
                Console.WriteLine("4. File Manager");
                Console.WriteLine("Press ESC to exit.");

                keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    Console.WriteLine("Exiting program...");
                    break;
                }

                int choice;
                if (!int.TryParse(keyInfo.KeyChar.ToString(), out choice))
                {
                    Console.WriteLine("Not Valid");
                    continue;
                }

                switch (choice)
                {
                    case 1: // Clinic Manager
                        while (true)
                        {
                            Console.WriteLine("\n--- Clinic Menu ---");
                            Console.WriteLine("1. Add Doctor");
                            Console.WriteLine("2. Remove Doctor");
                            Console.WriteLine("3. Update Doctor");
                            Console.WriteLine("4. View All Doctors");
                            Console.WriteLine("5. Add Patient");
                            Console.WriteLine("6. Remove Patient");
                            Console.WriteLine("7. Update Patient");
                            Console.WriteLine("8. View All Patients");
                            Console.WriteLine("9. Get Patient By Phone");
                            Console.WriteLine("10. Back To Main Menu");
                            Console.Write("Enter choice: ");

                            //Clinic Choice
                            string input = Console.ReadLine();
                            int clinicChoice;
                            if (!int.TryParse(input, out clinicChoice))
                            {
                                Console.WriteLine("Invalid input");
                                continue;
                            }

                            switch (clinicChoice)
                            {
                                case 1: // Add Doctor
                                    string dname = Utility.InputNonEmpty("Enter doctor name: ");
                                    string dspec = Utility.InputNonEmpty("Enter specialty: ");
                                    decimal dprice = Utility.InputDecimal("Enter price: ");
                                    Doctor.AddDoctor(new Doctor(dname, dprice, dspec));
                                    break;

                                case 2: // Remove Doctor
                                    string removeDoctor = Utility.InputNonEmpty("Enter doctor name to remove: ");
                                    string removeSpecialty = Utility.InputNonEmpty("Enter specialty: ");
                                    Doctor.RemoveDoctor(removeDoctor, removeSpecialty);
                                    break;

                                case 3: // Update Doctor
                                    string oldName = Utility.InputNonEmpty("Enter current doctor name: ");
                                    string oldSpecialty = Utility.InputNonEmpty("Enter current specialty: ");
                                    string newName = Utility.InputNonEmpty("Enter new doctor name: ");
                                    string newSpecialty = Utility.InputNonEmpty("Enter new specialty: ");
                                    decimal newPrice = Utility.InputDecimal("Enter new price: ");
                                    Doctor.UpdateDoctor(oldName, oldSpecialty, newName, newSpecialty, newPrice);
                                    break;

                                case 4: // View All Doctors
                                    Doctor.ViewDoctors();
                                    break;

                                case 5: // Add Patient
                                    string pname = Utility.InputName();
                                    string pphone = Utility.InputPhone();
                                    string pemail = Utility.InputEmail();
                                    patient.AddPatient(new Patient(pname, pphone, pemail));
                                    Console.WriteLine("Patient added ");
                                    break;

                                case 6: // Remove Patient
                                    Console.Write("Enter phone to delete patient: ");
                                    string delPhone = Console.ReadLine();
                                    patient.DeletePatient(delPhone);
                                    break;

                                case 7: // Update Patient
                                    Console.Write("Enter phone of patient to update: ");
                                    string upPhone = Console.ReadLine();
                                    Console.Write("Enter new name: ");
                                    string upName = Console.ReadLine();
                                    Console.Write("Enter new email: ");
                                    string upEmail = Console.ReadLine();
                                    patient.UpdatePatient(upPhone, upName, upEmail);
                                    break;

                                case 8: // View All Patients
                                    patient.ViewPatients();
                                    break;

                                case 9: // Get Patient By Phone
                                    Console.Write("Enter phone to search: ");
                                    string searchPhone = Console.ReadLine();
                                    var found = patient.GetPatientByPhone(searchPhone);
                                    if (found == null)
                                        Console.WriteLine("Patient not found.");
                                    else
                                        Console.WriteLine($"Id: {found.Id} Name: {found.Name} Phone: {found.Phone} Email: {found.Email}");
                                    break;

                                case 10: // Back to Main Menu
                                    goto EndClinicMenu;

                                default:
                                    Console.WriteLine("مفيش");
                                    break;
                            }
                        }
                    EndClinicMenu:
                        break;

                    case 2: // Schedule Manager
                        while (true)
                        {
                            Console.WriteLine("\n--- Schedule Menu ---");
                            Console.WriteLine("1. Add Appointment");
                            Console.WriteLine("2. Update Appointment");
                            Console.WriteLine("3. Remove Appointment");
                            Console.WriteLine("4. View Appointments");
                            Console.WriteLine("5. Back to Main Menu");
                            Console.Write("Enter choice: ");

                            string sin = Console.ReadLine();
                            int schChoice;
                            if (!int.TryParse(sin, out schChoice))
                            {
                                Console.WriteLine("Invalid input");
                                continue;
                            }

                            switch (schChoice)
                            {
                                case 1: // Add Appointment
                                    string docName = Utility.InputNonEmpty("Enter doctor name: ");
                                    string docSpec = Utility.InputNonEmpty("Enter doctor specialty: ");
                                    var doc = Doctor.GetDoctorByNameAndSpecialty(docName, docSpec);
                                    if (doc == null)
                                    {
                                        Console.WriteLine("Doctor not found.");
                                        break;
                                    }
                                    string patPhone = Utility.InputPhone();
                                    Patient pat = patient.GetPatientByPhone(patPhone);
                                    if (pat == null)
                                    {
                                        Console.WriteLine("Patient not found.");
                                        break;
                                    }
                                    DateTime dt = Utility.InputDateTimeExact("Enter appointment date and time (yyyy-MM-dd HH:mm): ");
                                    try
                                    {
                                        appointmentService.AddAppointment(pat, doc, dt);
                                        Console.WriteLine("Appointment added.");
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine($"Failed to add appointment: {ex.Message}");
                                    }
                                    break;

                                case 2: // Update Appointment
                                    string exDocName = Utility.InputNonEmpty("Enter existing doctor name for appointment: ");
                                    string exDocSpec = Utility.InputNonEmpty("Enter specialty: ");
                                    DateTime exDt = Utility.InputDateTimeExact("Enter appointment date and time (yyyy-MM-dd HH:mm): ");
                                    Doctor existingDoc = Doctor.GetDoctorByNameAndSpecialty(exDocName, exDocSpec);
                                    Appointment existingAppointment = appointmentService.GetAppointment(existingDoc, exDt);
                                    if (existingAppointment == null)
                                    {
                                        Console.WriteLine("Appointment not found.");
                                        break;
                                    }
                                    string nDocName = Utility.InputNonEmpty("Enter new doctor name: ");
                                    string nDocSpec = Utility.InputNonEmpty("Enter new doctor specialty: ");
                                    Doctor newDoc = Doctor.GetDoctorByNameAndSpecialty(nDocName, nDocSpec);
                                    if (newDoc == null)
                                    {
                                        Console.WriteLine("New doctor not found.");
                                        break;
                                    }
                                    string nPatPhone = Utility.InputPhone();
                                    var newPat = patient.GetPatientByPhone(nPatPhone);
                                    if (newPat == null)
                                    {
                                        Console.WriteLine("New patient not found.");
                                        break;
                                    }
                                    DateTime newDt = Utility.InputDateTimeExact("Enter new date and time (yyyy-MM-dd HH:mm): ");
                                    try
                                    {
                                        appointmentService.UpdateAppointment(existingAppointment, newPat, newDoc, newDt);
                                        Console.WriteLine("Appointment updated.");
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine($"Failed to update appointment: {ex.Message}");
                                    }
                                    break;

                                case 3: // Remove Appointment
                                    string remDoc = Utility.InputNonEmpty("Enter doctor name for appointment to remove: ");
                                    string remSpec = Utility.InputNonEmpty("Enter specialty: ");
                                    DateTime remDt = Utility.InputDateTimeExact("Enter appointment date and time (yyyy-MM-dd HH:mm): ");
                                    var remDoctor = Doctor.GetDoctorByNameAndSpecialty(remDoc, remSpec);
                                    var remAppointment = appointmentService.GetAppointment(remDoctor, remDt);
                                    if (remAppointment == null)
                                    {
                                        Console.WriteLine("Appointment not found.");
                                        break;
                                    }
                                    try
                                    {
                                        appointmentService.DeleteAppointment(remAppointment);
                                        Console.WriteLine("Appointment removed.");
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine($"Failed to remove appointment: {ex.Message}");
                                    }
                                    break;

                                case 4:
                                    appointmentService.ViewAppointments();
                                    break;

                                case 5:
                                    goto EndScheduleMenu;

                                default:
                                    Console.WriteLine("Invalid choice");
                                    break;
                            }
                        }
                    EndScheduleMenu:
                        break;

                    case 3: // Payment Manager
                        while (true)
                        {
                            Console.WriteLine("\n--- Payment Menu ---");
                            Console.WriteLine("1. Add Payment");
                            Console.WriteLine("2. Delete Payment");
                            Console.WriteLine("3. View All Payments");
                            Console.WriteLine("4. Get Payment By Id");
                            Console.WriteLine("5. Back to Main Menu");
                            Console.Write("Enter choice: ");

                            string pin = Console.ReadLine();
                            int payChoice;
                            if (!int.TryParse(pin, out payChoice))
                            {
                                Console.WriteLine("Invalid input");
                                continue;
                            }

                            switch (payChoice)
                            {
                                case 1: // Add Payment
                                    string payPatPhone = Utility.InputPhone();
                                    Patient payPat = patient.GetPatientByPhone(payPatPhone);
                                    if (payPat == null)
                                    {
                                        Console.WriteLine("Patient not found.");
                                        break;
                                    }
                                    Console.Write("Enter amount: ");
                                    decimal amount = Utility.InputDecimal("Enter amount: ");
                                    Console.Write("Enter payment date (yyyy-MM-dd) or leave empty for today: ");
                                    string dateInput = Console.ReadLine();
                                    DateTime payDate;
                                    if (string.IsNullOrWhiteSpace(dateInput))
                                        payDate = DateTime.Now;
                                    else
                                    {
                                        payDate = Utility.InputDateExact("Enter payment date (yyyy-MM-dd): ");
                                    }
                                    paymentService.AddPayment(new Entities.Payment(payPat, amount, payDate));
                                    break;

                                case 2: // Delete Payment
                                    Console.Write("Enter payment id to delete: ");
                                    int delId;
                                    if (!int.TryParse(Console.ReadLine(), out delId))
                                    {
                                        Console.WriteLine("Invalid id");
                                        break;
                                    }
                                    paymentService.DeletePayment(delId);
                                    break;

                                case 3: // View All Payments
                                    paymentService.ViewPayments();
                                    break;

                                case 4: // Get Payment By Id
                                    Console.Write("Enter payment id: ");
                                    int getId;
                                    if (!int.TryParse(Console.ReadLine(), out getId))
                                    {
                                        Console.WriteLine("Invalid id");
                                        break;
                                    }
                                    Payment got = paymentService.GetPaymentById(getId);
                                    if (got == null)
                                        Console.WriteLine("Payment not found.");
                                    else
                                        Console.WriteLine($"Id: {got.Id} | Patient: {got.Patient.Name} | Amount: {got.Amount} | Date: {got.Date}");
                                    break;

                                case 5:
                                    goto EndPaymentMenu;

                                default:
                                    Console.WriteLine("Invalid choice");
                                    break;
                            }
                        }
                    EndPaymentMenu:
                        break;

                    case 4: //file 
                        Console.Write("Enter output file path : ");
                        string outPath = Console.ReadLine();
                        try
                        {
                            fileService.SaveAllAndClear(
                                Doctor.GetDoctorsList(),
                                patient.GetPatientsList(),
                                paymentService.GetPaymentsList(),
                                appointmentService.GetAppointmentsList(),outPath);
                            Console.WriteLine($"Data exported to {outPath} and lists cleared.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Failed to export data: {ex.Message}");
                        }
                        break;

                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
            }
        }
    }
}