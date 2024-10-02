namespace Models
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        public Person(string firstName, string lastName, DateTime dateOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = dateOfBirth;
        }

        public Person()
        {
            FirstName = "";
            LastName = "";
            BirthDate = new DateTime(2000, 1, 1);
        }
    }
}
