namespace SPG_Fachtheorie.Aufgabe1.Model
{
    public class Address
    {
        public Address() { }

        public Address(string street, string city, string zip)
        {
            Street = street;
            City = city;
            Zip = zip;
        }

        [Required]
        [MaxLength(255)]
        public string Street { get; set; }

        [Required]
        [MaxLength(255)]
        public string City { get; set; }

        [Required]
        [MaxLength(10)]
        public string Zip { get; set; }
    }
}