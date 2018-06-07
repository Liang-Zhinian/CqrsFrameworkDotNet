using System;
using CqrsFramework.Domain;

namespace MAR.Domain
{
    public class Person : AggregateRoot
    {
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
