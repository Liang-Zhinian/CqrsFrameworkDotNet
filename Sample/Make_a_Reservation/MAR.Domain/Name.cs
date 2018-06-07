using System;
namespace MAR.Domain
{
    public class Name
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string DisplayName { get; set; }
        public string NickName { get; set; }

        public Name(string firstName, string lastName, string middleName="", string displayName= "", string nickName= "")
        {
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
            DisplayName = displayName;
            NickName = nickName;
        }
    }
}
