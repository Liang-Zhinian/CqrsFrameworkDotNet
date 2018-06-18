using System;
using CqrsFramework.Domain;
using CqrsFramework.Extensions;
using Business.Domain.Models.Enums;

namespace Business.Domain.Models.ValueObjects
{
    public class PersonalInfo: ValueObject<PersonalInfo>
    {
        public PersonName Name { get; set; }
        public Contact Contact { get; set; }
        public Address Address { get; set; }
        public bool IsMale { get; set; }
        public string Bio { get; set; }
        public Image Photo { get; set; }

        public PersonalInfo(PersonName name,Contact contact,Address address,bool isMale, string bio, Image photo)
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
