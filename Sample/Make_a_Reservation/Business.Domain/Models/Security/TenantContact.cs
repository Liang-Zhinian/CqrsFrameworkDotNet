using System;
using System.ComponentModel.DataAnnotations;
namespace Business.Domain.Models.Security
{
    public class TenantContact : BaseObject
    {
        public Guid ContactId { get; set; }
        public virtual Contact Contact { get; set; }
    }
}
