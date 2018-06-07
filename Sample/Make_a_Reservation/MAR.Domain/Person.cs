using System;
namespace MAR.Domain
{
    public class Person
    {
        public Guid Id { get; set; }
        public Name Name { get; set; }
        public Contact Contact { get; set; }
        public Address Address { get; set; }
        public Profile Profile { get; set; }
        public Gender Gender { get; set; }

        public Person()
        {
        }
    }
}
