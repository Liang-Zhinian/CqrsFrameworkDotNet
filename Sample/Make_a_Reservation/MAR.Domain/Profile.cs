using System;
using CqrsFramework.Domain;
using CqrsFramework.Extensions.Domain;

namespace MAR.Domain
{
    public class Profile
    {
        public Guid Id { get; set; }
        public Participator Owner { get; set; }
        
        public Profile()
        {
        }
    }
}
