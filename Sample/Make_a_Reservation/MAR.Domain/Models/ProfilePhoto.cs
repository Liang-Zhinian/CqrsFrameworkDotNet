using System;
namespace MAR.Domain.Models
{
    public class ProfilePhoto
    {
        public Guid Id { get; set; }
        public Profile Profile { get; set; }
        public Photo Photo { get; set; }

        public ProfilePhoto()
        {
        }
    }
}
