using System;
using System.ComponentModel.DataAnnotations;
namespace Business.Domain.Models.Security
{
    public class StaffLoginCredential : BaseObject
    {

        public string UserName { get; set; }
        public string Password { get; set; }

        public Guid StaffId { get; set; }
        public virtual Staff Staff { get; set; }
    }
}
