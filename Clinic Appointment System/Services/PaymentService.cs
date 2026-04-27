using Clinic_Appointment_System.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clinic_Appointment_System.Services
{
    internal class PaymentService
    {
        private List<Payment> Payments;
        public PaymentService()
        {
            Payments = new List<Payment>();
        }
        public void AddPayment(Payment payment)
        {
            if (payment == null)
            {
                Console.WriteLine("Empty"); 
                return;
            }

            Payments.Add(payment);
            Console.WriteLine($"Payment added: {payment.Patient.Name}, Amount: {payment.Amount}");
        }

        public void ViewPayments()
        {
            if (Payments.Count == 0)
            {
                Console.WriteLine("No payments Exists");
                return;
            }

            foreach (var p in Payments)
            {
                Console.WriteLine($"Id: {p.Id} | Patient: {p.Patient.Name} | Amount: {p.Amount} | Date: {p.Date}");
            }
        }

        public void DeletePayment(int id)
        {
            var deleted = GetPaymentById(id);

            if (deleted == null)
            {
                Console.WriteLine("there is no payment with this id");
            }
            else
            {
                Payments.Remove(deleted);
            }
        }


        public Payment GetPaymentById(int id)
        {
            foreach (var x in Payments)
            {
                if (x.Id == id)
                {
                    return x;
                }
            }
            return null;
        }

        // Expose internal payments list for file operations
        public List<Payment> GetPaymentsList()
        {
            return Payments;
        }

    }
}
