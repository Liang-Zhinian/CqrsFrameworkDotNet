using System;
using System.ComponentModel.DataAnnotations;
using Business.Contracts;

namespace Business.Domain.Identity.Entities
{
    public class TenantContact
    {
        public Guid Id { get; private set; }

        [Display(Name = "Email")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "The Email field is required.")]
        [EmailAddress(ErrorMessage = "The Email field is not a valid email address.")]
        [RegularExpression(@"[\w-]+(\.?[\w-])*\@[\w-]+(\.[\w-]+)+")]
        public string Email { get; private set; }

        public string PrimaryTelephone { get; private set; }

        public string SecondaryTelephone { get; private set; }

        public TenantId TenantId { get; private set; }

        public TenantContact(TenantId tenantId,
                             string email,
                             string primaryTelephone,
                             string secondaryTelephone)
        {
            Id = Guid.NewGuid();
            this.TenantId = tenantId;
            Email = email;
            PrimaryTelephone = primaryTelephone;
            SecondaryTelephone = secondaryTelephone;
        }

    }
}
