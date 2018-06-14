using System;
using System.ComponentModel.DataAnnotations;
using Business.Domain.Models.ValueObjects;

namespace Business.Domain.Models.Security
{
    public class LocationContact : BaseObject
    {
        [Display(Name = "Email")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "The Email field is required.")]
        [EmailAddress(ErrorMessage = "The Email field is not a valid email address.")]
        [RegularExpression(@"[\w-]+(\.?[\w-])*\@[\w-]+(\.[\w-]+)+")]
        public string Email { get; set; }

        [EmailAddress(ErrorMessage = "The Email field is not a valid email address.")]
        [Display(Name = "Email")]
        [Required(AllowEmptyStrings = true)]
        [RegularExpression(@"[\w-]+(\.?[\w-])*\@[\w-]+(\.[\w-]+)+")]
        public string Email2 { get; set; }
        public string Phone { get; set; }
        public string Phone2 { get; set; }
        public string Phone3 { get; set; }

        public Guid LocationId { get; set; }
        public virtual Location Location { get; set; }

        public LocationContact()
        {

        }

        public LocationContact(Guid locationId, Guid tenantId) : base(tenantId)
        {
            LocationId = locationId;
        }

        public LocationContact(Guid locationId,
                            Guid tenantId,
                             string email,
                             string email2,
                             string phone,
                             string phone2,
                               string phone3) : this(locationId, tenantId)
        {
            Email = email;
            Email2 = email2;
            Phone = phone;
            Phone2 = phone2;
            Phone3 = phone3;
        }
    }
}
