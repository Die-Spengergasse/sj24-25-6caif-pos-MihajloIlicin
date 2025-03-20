namespace SPG_Fachtheorie.Aufgabe1.Model
{
    public class Cashier : Employee
    {
        public Cashier(int registrationNumber, string firstName, string lastName, ICollection<Address> addresses, string jobSpecialisation)
            : base(registrationNumber, firstName, lastName, addresses)
        {
            JobSpecialisation = jobSpecialisation;
            Type = "Cashier";
        }

        [Required]
        [MaxLength(255)]
        public string JobSpecialisation { get; set; }
    }
}