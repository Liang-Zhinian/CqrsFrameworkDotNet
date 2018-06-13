using System;
using System.ComponentModel.DataAnnotations;
namespace Business.Domain.Models.Security
{
    public class TenantAddress : BaseObject
    {
        public Guid AddressId { get; set; }
        public virtual Address Address { get; set; }
    }
}
