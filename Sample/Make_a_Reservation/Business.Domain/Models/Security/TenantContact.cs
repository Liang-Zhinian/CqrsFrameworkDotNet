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

        [EmailAddress(ErrorMessage = "The Email field is not a valid email address.")]
        [Display(Name = "Email")]
        [RegularExpression(@"[\w-]+(\.?[\w-])*\@[\w-]+(\.[\w-]+)+")]
        public string Email2 { get; set; }

        public string Phone { get; set; }
        public string Phone2 { get; set; }
        public string Phone3 { get; set; }

        public TenantContact()
        {

        }

        public TenantContact(Guid tenantId) : base(tenantId)
        {
            Id = GuidUtil.NewSequentialId();
        }

        public TenantContact(Guid tenantId,
                             string email,
                             string email2,
                             string phone,
                             string phone2,
                             string phone3) : this(tenantId)
        {
            Email = email;
            Email2 = email2;
            Phone = phone;
            Phone2 = phone2;
            Phone3 = phone3;
        }
    }
}
