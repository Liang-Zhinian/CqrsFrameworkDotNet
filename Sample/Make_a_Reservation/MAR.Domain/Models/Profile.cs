using System;
using CqrsFramework.Domain;
using CqrsFramework.Extensions;

namespace MAR.Domain.Models
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
