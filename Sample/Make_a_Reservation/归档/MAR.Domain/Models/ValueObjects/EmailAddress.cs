using System;
using CqrsFramework.Domain;

namespace MAR.Domain.Models.ValueObjects
{
    public class EmailAddress : ValueObject<EmailAddress>
    {
        public bool IsBlacklisted { get; set; }
        public string Email { get; set; }

        public EmailAddress(string emailAddress)
        {
            ChangeEmailAddress(emailAddress);
        }

        public void ChangeEmailAddress(string email)
        {
            if (!IsValidEmail(email)) throw new FormatException("Invalid Email Address.");
            Email = email;
        }

        public bool IsValidEmail(string email)
        {
            return true;
        }
    }
}
