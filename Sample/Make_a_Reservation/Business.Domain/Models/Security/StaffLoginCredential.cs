using System;
using System.ComponentModel.DataAnnotations;
namespace Business.Domain.Models.Security
{
    public class StaffLoginCredential : BaseObject
    {

        public string UserName { get; set; }

        [Required(ErrorMessage = "The Password field is required.")]
        [StringLength(8, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public Guid StaffId { get; set; }
        public virtual Staff Staff { get; set; }

        public StaffLoginCredential()
        {

        }

        public StaffLoginCredential(Guid staffId, Guid tenantId) : base(tenantId)
        {
            StaffId = staffId;
        }
    }
}
