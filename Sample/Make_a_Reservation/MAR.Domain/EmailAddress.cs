using System;
namespace MAR.Domain
{
    public class EmailAddress
    {
        private bool _isBlacklisted;
        private string _email;

        public EmailAddress(string emailAddress)
        {
            ChangeEmailAddress(emailAddress);
        }

        public void ChangeEmailAddress(string email)
        {
            if (!IsValidEmail(email)) throw new FormatException("Invalid Email Address.");
            _email = email;
        }

        public bool IsValidEmail(string email)
        {
            return true;
        }
    }
}
