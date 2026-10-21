# 🏥 Clinic Appointment System (C# Console App)

A **C# / .NET** console application for managing a small clinic — doctors, patients, appointments and payments.
Built during the **ITI .NET track** to practice **Object-Oriented Programming**, interfaces and clean separation of responsibilities.

---

## ✨ Features
| Area | What you can do |
|---|---|
| 👨‍⚕️ **Doctors** | Add, update, remove, list (name, specialty, consultation price) |
| 🧑 **Patients** | Add, update, remove, list, **search by phone number** |
| 📅 **Appointments** | Book, reschedule, cancel, list — **prevents double-booking** a doctor at the same time |
| 💳 **Payments** | Record a payment, delete, list, find by ID |
| 💾 **Export** | Save all clinic data to a text file report |
| ✅ **Input validation** | Safe input helpers for names, phone, email, prices and dates — the app never crashes on bad input |

## 🧠 OOP concepts applied
- **Encapsulation** — each entity (`Doctor`, `Patient`, `Appointment`, `Payment`) controls its own data
- **Abstraction with interfaces** — `IDoctorService`, `IPatientService`, `IAppointmentService`, `IFileServices`
- **Single Responsibility** — entities hold data, services hold the business rules, `Utility` handles user input, `Program` only shows menus
- **Business rules in one place** — e.g. a doctor can't have two appointments at the same date & time

## 📂 Project structure
```
Clinic Appointment System/
├── Entities/          → Doctor, Patient, Appointment, Payment
├── Services/          → business logic for each entity + file export
│   └── Interfaces/    → service contracts
├── InputHandler/      → Utility: validated console input
└── Program.cs         → menus (Clinic, Schedule, Payment, File)
```

## ▶️ How to run
**Requirements:** .NET 10 SDK

```bash
git clone https://github.com/Mohamed-Elhosinii/Clinic-Appointment-System.git
cd "Clinic-Appointment-System/Clinic Appointment System"
dotnet run
```
Or open `Clinic Appointment System.slnx` in Visual Studio and press **F5**.

## 🚀 Next steps
- Save and load data from a JSON file or SQL Server (EF Core) instead of memory
- Unit tests for the services (xUnit)
- Turn it into an ASP.NET Core Web API

## 🛠️ Tech
C# · .NET 10 · OOP · Console App

---
👤 **Mohamed Mostafa Elhoseny** — [LinkedIn](https://www.linkedin.com/in/mohamed-mostafa-655917273) · [GitHub](https://github.com/Mohamed-Elhosinii)
