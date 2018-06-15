﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Registration.Domain.ReadModel.Security
{
    public class Tenant
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Phone { get; set; }
        public string Phone2 { get; set; }
        public string Phone3 { get; set; }
        public string Street { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string ForeignZip { get; set; }
        public string LogoURL { get; set; }
        public string PageColor1 { get; set; }
        public string PageColor2 { get; set; }
        public string PageColor3 { get; set; }
        public string PageColor4 { get; set; }

        public ICollection<Location> Locations { get; set; }
        public ICollection<Staff> Staffs { get; set; }
    }
}
