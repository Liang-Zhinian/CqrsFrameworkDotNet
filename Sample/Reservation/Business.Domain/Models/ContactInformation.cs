using System;
using CqrsFramework.Domain;

namespace Business.Domain.Models
{
    public class ContactInformation: ValueObject<ContactInformation>
    {
        public ContactInformation()
        {
        }

        public string ContactName { get; private set; }

        public string PrimaryTelephone { get; private set; }

        public string SecondaryTelephone { get; private set; }
    }
}
