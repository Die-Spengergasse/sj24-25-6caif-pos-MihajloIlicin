using System;

namespace SPG_Fachtheorie.Aufgabe1.Model
{
    public class Payment
    {
        protected Payment() { }

        public Payment(int paymentId, CashDesk cashDesk, DateTime paymentDateTime, PaymentType paymentType, Employee employee, ICollection<PaymentItem> paymentItems)
        {
            PaymentId = paymentId;
            CashDesk = cashDesk;
            PaymentDateTime = paymentDateTime;
            PaymentType = paymentType;
            Employee = employee;
            PaymentItems = paymentItems;
        }

        [Key]
        public int PaymentId { get; set; }

        public CashDesk CashDesk { get; set; }

        [Required]
        public DateTime PaymentDateTime { get; set; }

        [Required]
        public PaymentType PaymentType { get; set; }

        public Employee Employee { get; set; }

        public ICollection<PaymentItem> PaymentItems { get; set; } = new List<PaymentItem>();

    }
}