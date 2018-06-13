using System;
using System.ComponentModel.DataAnnotations;
namespace Business.Domain.Models.Security
{
    public class StaffContact : BaseObject
    {
        public Guid ContactId { get; set; }
        public virtual Contact Contact { get; set; }

        public Guid StaffId { get; set; }
        public virtual Staff Staff { get; set; }
    }
}
