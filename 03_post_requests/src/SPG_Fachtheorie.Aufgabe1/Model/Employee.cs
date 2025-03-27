using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SPG_Fachtheorie.Aufgabe1.Model
{
    public abstract class Employee
    {
        protected Employee() { }
        public Employee(int registrationNumber, string firstName, string lastName, ICollection<Address> addresses)
        {
            RegistrationNumber = registrationNumber;
            FirstName = firstName;
            LastName = lastName;
            Addresses = addresses;
        }

        [Key]
        public int RegistrationNumber { get; set; }

        [Required]
        [MaxLength(255)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(255)]
        public string LastName { get; set; }

        public ICollection<Address> Addresses { get; set; } = new List<Address>();

        public string Type { get; private set; }
    }
}