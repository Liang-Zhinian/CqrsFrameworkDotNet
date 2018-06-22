using System;
using System.ComponentModel.DataAnnotations;
using Business.Domain.Models.ValueObjects;
using CqrsFramework.Domain;
using Infrastructure.Utils;

namespace Business.Domain.Models.Security
{
    public class TenantContact : AggregateRoot
    {
        [Display(Name = "Email")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "The Email field is required.")]
        [EmailAddress(ErrorMessage = "The Email field is not a valid email address.")]
        [RegularExpression(@"[\w-]+(\.?[\w-])*\@[\w-]+(\.[\w-]+)+")]
        public string Email { get; private set; }

        public string PrimaryTelephone { get; private set; }

        public string SecondaryTelephone { get; private set; }

        public Guid TenantId { get; private set; }
        //public string TenantId_Id { get; private set; }

        public TenantContact(Guid tenantId,
                             string email,
                             string primaryTelephone,
                             string secondaryTelephone)
        {
            Id = GuidUtil.NewSequentialId();
            this.TenantId = tenantId;
            Email = email;
            PrimaryTelephone = primaryTelephone;
            SecondaryTelephone = secondaryTelephone;
        }

    }
}
