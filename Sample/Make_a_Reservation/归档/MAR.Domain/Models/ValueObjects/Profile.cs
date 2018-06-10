using System;
using CqrsFramework.Domain;
using CqrsFramework.Extensions;
using MAR.Domain.Models.Enums;

namespace MAR.Domain.Models.ValueObjects
{
    public class Profile: ValueObject<Profile>
    {
        public PersonName Name { get; set; }
        public Contact Contact { get; set; }
        public Address Address { get; set; }
        public bool IsMale { get; set; }
        public string Bio { get; set; }
        public Image Photo { get; set; }

        public Profile(PersonName name,Contact contact,Address address,bool isMale, string bio, Image photo)
        {
            Name = name;
            Contact = contact;
            Address = address;
            IsMale = isMale;
            Bio = bio;
            Photo = photo;
        }
    }
}
