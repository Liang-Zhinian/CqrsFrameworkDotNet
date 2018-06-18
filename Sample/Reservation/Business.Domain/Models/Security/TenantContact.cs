using System;
using System.ComponentModel.DataAnnotations;
using Business.Domain.Models.ValueObjects;
using Infrastructure.Utils;

namespace Business.Domain.Models.Security
{
    public class TenantContact : BaseObject
    {
        [Display(Name = "Email")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "The Email field is required.")]
        [EmailAddress(ErrorMessage = "The Email field is not a valid email address.")]
        [RegularExpression(@"[\w-]+(\.?[\w-])*\@[\w-]+(\.[\w-]+)+")]
        public string Email { get; set; }

        //[EmailAddress(ErrorMessage = "The Email field is not a valid email address.")]
        //[Display(Name = "Email")]
        //[RegularExpression(@"[\w-]+(\.?[\w-])*\@[\w-]+(\.[\w-]+)+")]
        //public string Email2 { get; set; }


        public string PrimaryTelephone { get; set; }

        public string SecondaryTelephone { get; set; }

        public TenantContact()
        {

        }

        public TenantContact(Guid tenantId) : base(tenantId)
        {
            Id = GuidUtil.NewSequentialId();
        }

        public TenantContact(Guid tenantId,
                             string email,
                             string primaryTelephone,
                             string secondaryTelephone) : this(tenantId)
        {
            Email = email;
            PrimaryTelephone = primaryTelephone;
            SecondaryTelephone = secondaryTelephone;
        }
    }
}
