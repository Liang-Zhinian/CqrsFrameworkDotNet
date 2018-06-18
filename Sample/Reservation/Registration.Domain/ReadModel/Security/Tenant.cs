using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Registration.Domain.ReadModel.Security
{
    public class Tenant
    {
        [Key]
        public Guid Id { get; private set; }

        [Required(ErrorMessage = "The Name is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Name")]
        public string Name { get; private set; }

        [MinLength(2)]
        [MaxLength(2000)]
        [DisplayName("Description")]
        public string Description { get; private set; }

        public string Email { get; private set; }

        public PostalAddress PostalAddress { get; private set; }

        [Required(ErrorMessage = "The PrimaryTelephone is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("PrimaryTelephone")]
        public string PrimaryTelephone { get; private set; }

        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("SecondaryTelephone")]
        public string SecondaryTelephone { get; private set; }

        public string LogoURL { get; private set; }

        public string PageColor1 { get; private set; }

        public string PageColor2 { get; private set; }

        public string PageColor3 { get; private set; }

        public string PageColor4 { get; private set; }

        public ICollection<Location> Locations { get; private set; }

        public ICollection<Staff> Staffs { get; private set; }
    }
}
