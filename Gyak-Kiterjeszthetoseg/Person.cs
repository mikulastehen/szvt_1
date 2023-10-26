namespace Gyak_Kiterjeszthetoseg
{
    internal class Person
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string CompanyName { get; }
        public string Address { get; }
        public string City { get; }
        public string State { get; }

        public Person(string firstName, string lastName, string companyName, string address, string city, string state)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.CompanyName = companyName;
            this.Address = address;
            this.City = city;
            this.State = state;
        }
    }
}