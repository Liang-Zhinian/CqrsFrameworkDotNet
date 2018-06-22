using System;
namespace Business.Domain.Models
{
    public class UserId
    {
        public Guid Id { get; private set; }

        public UserId(Guid id)
        {
            this.Id = id;
        }
    }
}
