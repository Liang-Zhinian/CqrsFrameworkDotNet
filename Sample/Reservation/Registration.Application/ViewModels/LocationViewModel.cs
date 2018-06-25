using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Infrastructure.Utils;

namespace Registration.Application.ViewModels
{
    public class LocationViewModel
    {
        public Guid Id { get; set; }

        public Guid BusinessID { get; set; }

        public string BusinessDescription { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public byte[] Image { get; set; }

        public string PrimaryTelephone { get; set; }

        public string SecondaryTelephone { get; set; }

        public string City { get; set; }

        public string CountryCode { get; set; }

        public string PostalCode { get; set; }

        public string StateProvince { get; set; }

        public string StreetAddress { get; set; }

        public string StreetAddress2 { get; set; }

        public ICollection<byte[]> AdditionalLocationImages { get; set; }

        public Guid SiteId { get; set; }

        public Guid TenantId { get; set; }

    }
}
