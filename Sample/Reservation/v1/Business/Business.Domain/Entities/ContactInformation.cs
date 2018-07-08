using System;
using System.Collections.Generic;
using CqrsFramework.Domain;

namespace Business.Domain.Entities
{
    public class ContactInformation: ValueObject<ContactInformation>
    {
        public string ContactName { get; private set; }

        public string EmailAddress { get; private set; }

        public string PrimaryTelephone { get; private set; }

        public string SecondaryTelephone { get; private set; }

        private ContactInformation()
        {
        }

        public ContactInformation(string contactName, string primaryTelephone, string secondaryTelephone, string emailAddress)
        {
            ContactName = contactName;
            PrimaryTelephone = primaryTelephone;
            SecondaryTelephone = secondaryTelephone;
            EmailAddress = emailAddress;
        }

        internal ContactInformation Empty()
        {
            return new ContactInformation();
        }
    }
}
