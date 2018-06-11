﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MAR.Infra.Data.Models.Security
{
    public class Staff
    {
        [Key]
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string DisplayName { get; set; }

        public bool IsMale { get; set; }

        public string Bio { get; set; }

        public string ImageUrl { get; set; }

        public StaffLoginCredential LoginCredential { get; set; }

        public StaffAddress Address { get; set; }

        public StaffContact Contact { get; set; }

        public ICollection<StaffLoginLocation> StaffLoginLocations { get; set; }

        public string BusinessId { get; set; }
        public Business Business { get; set; }
    }
}