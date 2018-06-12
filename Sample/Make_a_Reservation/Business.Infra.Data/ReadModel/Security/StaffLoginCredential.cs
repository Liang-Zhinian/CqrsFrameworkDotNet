using System;
using System.ComponentModel.DataAnnotations;
namespace Business.Infra.Data.ReadModel.Security
{
    public class StaffLoginCredential
    {
        [Key]
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string StaffId { get; set; }

        public virtual Staff Staff { get; set; }

        public StaffLoginCredential()
        {
        }
    }
}
