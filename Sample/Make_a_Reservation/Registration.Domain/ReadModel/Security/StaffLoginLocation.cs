﻿using System;
using System.ComponentModel.DataAnnotations;
namespace Registration.Domain.ReadModel.Security
{
    public class StaffLoginLocation
    {
        [Key]
        public string Id { get; set; }

        public string StaffId { get; set; }
        public Staff Staff { get; set; }

        public string LocationId { get; set; }
        public Location Location { get; set; }

        public StaffLoginLocation()
        {
        }
    }
}
