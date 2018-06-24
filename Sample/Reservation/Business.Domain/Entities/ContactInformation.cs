using System;
using CqrsFramework.Domain;

namespace Business.Domain.Entities
{
    public class ContactInformation: ValueObject<ContactInformation>
    {
        public ContactInformation()
        {
        }

        public string ContactName { get; set; }

        public string PrimaryTelephone { get; set; }

        public string SecondaryTelephone { get; set; }
    }
}
