using System;
using System.ComponentModel.DataAnnotations;
namespace Business.Domain.Models.Security
{
    public class StaffAddress : BaseObject
    {
        public Guid AddressId { get; set; }
        public virtual Address Address { get; set; }

        public Guid StaffId { get; set; }
        public virtual Staff Staff { get; set; }
    }
}
