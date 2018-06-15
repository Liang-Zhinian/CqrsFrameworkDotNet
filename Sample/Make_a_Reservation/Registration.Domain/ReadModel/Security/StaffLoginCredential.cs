using System;
using System.ComponentModel.DataAnnotations;
namespace Registration.Domain.ReadModel.Security
{
    public class StaffLoginCredential
    {
        [Key]
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public Guid StaffId { get; set; }

        public Staff Staff { get; set; }

        public StaffLoginCredential()
        {
        }
    }
}
