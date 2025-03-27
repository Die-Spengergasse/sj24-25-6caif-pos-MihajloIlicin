namespace SPG_Fachtheorie.Aufgabe1.Model
{
    public class Manager : Employee
    {
        public Manager(int registrationNumber, string firstName, string lastName, ICollection<Address> addresses)
            : base(registrationNumber, firstName, lastName, addresses)
        {
            Type = "Manager";
        }
    }
}