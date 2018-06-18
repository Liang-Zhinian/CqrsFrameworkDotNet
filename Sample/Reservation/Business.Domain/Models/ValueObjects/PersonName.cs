using System;
using CqrsFramework.Domain;

namespace Business.Domain.Models
{
    public class PersonName: ValueObject<PersonName>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string DisplayName { get; set; }
        public string NickName { get; set; }

        public PersonName(string firstName, string lastName, string middleName="", string displayName= "", string nickName= "")
        {
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
            DisplayName = displayName;
            NickName = nickName;
        }
    }
}
