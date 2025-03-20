namespace SPG_Fachtheorie.Aufgabe1.Model
{
    public class PaymentItem
    {
        protected PaymentItem() { }

        public PaymentItem(int paymentItemId, string articleName, int amount, decimal price, Payment payment)
        {
            PaymentItemId = paymentItemId;
            ArticleName = articleName;
            Amount = amount;
            Price = price;
            Payment = payment;
        }

        [Key]
        public int PaymentItemId { get; set; }

        [Required]
        [MaxLength(255)]
        public string ArticleName { get; set; }

        [Required]
        public int Amount { get; set; }

        [Required]
        public decimal Price { get; set; }

        public Payment Payment { get; set; }
    }
}