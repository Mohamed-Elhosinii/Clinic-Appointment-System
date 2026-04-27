using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Net.Mail;

namespace Clinic_Appointment_System.InputHandler
{
    public class Utility
    {
        public static string InputName()
        {
            string name;
            while (true)
            {
                Console.Write("Enter Patient Name: ");
                name = Console.ReadLine()?.Trim();

                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Name cannot be empty.");
                    continue;
                }

                if (char.IsDigit(name[0]))
                {
                    Console.WriteLine("Patient name cannot start with a digit.");
                    continue;
                }

                return name;
            }
        }
        public static DateTime InputDateTimeExact(string prompt)
        {
            DateTime dt;
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (DateTime.TryParseExact(input, "yyyy-MM-dd HH:mm", null, System.Globalization.DateTimeStyles.None, out dt))
                    return dt;
                Console.WriteLine("Invalid date/time. Use format: yyyy-MM-dd HH:mm (e.g. 2026-01-25 14:30)");
            }
        }
        public static DateTime InputDateExact(string prompt)
        {
            DateTime dt;
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                if (DateTime.TryParseExact(input, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out dt))
                    return dt;
                Console.WriteLine("Invalid date. Use format: yyyy-MM-dd (e.g. 2026-01-25)");
            }
        }
        public static string InputPhone()
        {
            string phone;
            Regex regex = new Regex(@"^(010|011|012|015)[0-9]{8}$");

            while (true)
            {
                Console.Write("Enter Phone: ");
                phone = Console.ReadLine();

                if (!regex.IsMatch(phone))
                {
                    Console.WriteLine("Invalid phone number. It must start with 010, 011, 012, or 015 and be 11 digits.");
                    continue;
                }

                return phone;

            }
        }
        public static string InputEmail()
        {
            string email;
            while (true)
            {
                Console.Write("Enter Email: ");
                email = Console.ReadLine()?.Trim();
                if (string.IsNullOrWhiteSpace(email))
                {
                    Console.WriteLine("Email cannot be empty.");
                    continue;
                }
                try
                {
                    var addr = new MailAddress(email);
                    return email;
                }
                catch
                {
                    Console.WriteLine("Invalid email format.");
                    continue;
                }
            }
        }
        public static string InputNonEmpty(string prompt)
        {
            string v;
            do
            {
                Console.Write(prompt);
                v = Console.ReadLine()?.Trim();
                if (string.IsNullOrWhiteSpace(v))
                    Console.WriteLine("Value cannot be empty.");
            } while (string.IsNullOrWhiteSpace(v));
            return v;
        }
        public static decimal InputDecimal(string prompt)
        {
            decimal value;
            while (true)
            {
                Console.Write(prompt);
                string s = Console.ReadLine();
                if (decimal.TryParse(s, out value))
                    return value;
                Console.WriteLine("Invalid decimal value.");
            }
        }

    }
}
