using System;
using System.ComponentModel.DataAnnotations;
namespace MAR.Infra.Data.Models.Security
{
    public class StaffLoginCredential
    {
        [Key]
        public string Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string StaffId { get; set; }

        public Staff Staff { get; set; }

        public StaffLoginCredential()
        {
        }
    }
}
