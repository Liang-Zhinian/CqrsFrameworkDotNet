using System;
using CqrsFramework.Domain;

namespace Business.Domain.Models.ValueObjects
{
    public class LoginCredential: ValueObject<LoginCredential>
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public LoginCredential(string username, string password)
        {
            UserName = username;
            Password = password;
        }
    }
}
